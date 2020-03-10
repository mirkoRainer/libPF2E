using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public class AbilityScoreArray
    {
        public AbilityScoreArray(List<AbilityScoreBoostFlaw> boostsAndFlaws)
        {
            propertiesOfThisClass = this.GetType().GetProperties();
            CalculateAbilityScores(boostsAndFlaws);
        }

        public AbilityScore Strength { get; private set; }
        public AbilityScore Dexterity { get; private set; }
        public AbilityScore Constitution { get; private set; }
        public AbilityScore Intelligence { get; private set; }
        public AbilityScore Wisdom { get; private set; }
        public AbilityScore Charisma { get; private set; }
        public int FreeBoostsAvailable { get; private set; }

        private readonly PropertyInfo[] propertiesOfThisClass;

        public void AddBoosts(List<AbilityScoreBoostFlaw> boosts)
        {
            foreach (var property in propertiesOfThisClass)
            {
                if (property.Name == "FreeBoostsAvailable") continue; // TODO: Make this better!
                if (boosts.Count == 0)
                    property.SetValue(this, new AbilityScore(10, property.Name));
                foreach (var boost in boosts)
                {
                    if (boost.Ability == Ability.Free.ToString())
                    {
                        FreeBoostsAvailable++;
                        continue;
                    }
                    if (boost.Ability == property.Name)
                    {
                        AbilityScore current = (AbilityScore)property.GetValue(this);
                        int increaseAmount = current.Score >= 18 ? 1 : 2;
                        property.SetValue(this, new AbilityScore(current.Score + increaseAmount, property.Name));
                    }
                }
            }
        }

        private void CalculateAbilityScores(List<AbilityScoreBoostFlaw> boostsAndFlaws)
        {
            Strength = new AbilityScore(10, Ability.Strength);
            Dexterity = new AbilityScore(10, Ability.Dexterity);
            Constitution = new AbilityScore(10, Ability.Constitution);
            Intelligence = new AbilityScore(10, Ability.Intelligence);
            Wisdom = new AbilityScore(10, Ability.Wisdom);
            Charisma = new AbilityScore(10, Ability.Charisma);
            foreach (var boostFlaw in boostsAndFlaws)
            {
                foreach (var property in propertiesOfThisClass)
                {
                    if (property.Name == "FreeBoostsAvailable") continue;
                    if (boostFlaw.Ability == Ability.Free.ToString())
                    {
                        continue;
                    }
                    if (boostFlaw.Ability == property.Name)
                    {
                        AbilityScore newAbilityScore;
                        AbilityScore abilityScore = property.GetValue(this) as AbilityScore;
                        if (boostFlaw.IsBoost)
                        {
                            newAbilityScore = new AbilityScore(abilityScore.Score + 2, abilityScore.Ability);
                        }
                        else
                        {
                            newAbilityScore = new AbilityScore(abilityScore.Score - 2, abilityScore.Ability);
                        }
                        property.SetValue(this, newAbilityScore);
                    }
                }
                if (boostFlaw.Ability == "Free")
                    FreeBoostsAvailable++;
            }
        }

        public void SetAbilityScore(int score, Ability ability)
        {
            foreach (var property in propertiesOfThisClass)
            {
                if (property.Name == ability.ToString())
                {
                    property.SetValue(this, new AbilityScore(score, ability));
                    return;
                }
            }
        }

        public void SetAbilityScore(AbilityScore abilityScore)
        {
            foreach (var property in propertiesOfThisClass)
            {
                if (property.Name == abilityScore.Ability.ToString())
                {
                    property.SetValue(this, abilityScore);
                    return;
                }
            }
        }
    }
}