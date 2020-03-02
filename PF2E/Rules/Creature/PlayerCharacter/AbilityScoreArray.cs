using System.Collections.Generic;
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

        public AbilityScore Strength { get; set; }
        public AbilityScore Dexterity { get; set; }
        public AbilityScore Constitution { get; set; }
        public AbilityScore Intelligence { get; set; }
        public AbilityScore Wisdom { get; set; }
        public AbilityScore Charisma { get; set; }
        public int FreeBoostsAvailable { get; set; }

        private readonly PropertyInfo[] propertiesOfThisClass;

        public void AddBoosts(List<AbilityScoreBoostFlaw> boosts)
        {
            foreach (var property in propertiesOfThisClass)
            {
                if(property.Name == "FreeBoostsAvailable") continue; // TODO: Make this better!
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
            foreach (var property in propertiesOfThisClass)
            {
                if (property.Name == "FreeBoostsAvailable") continue;
                int total = 10;
                foreach (var boostFlaw in boostsAndFlaws)
                {
                    if (boostFlaw.Ability == Ability.Free.ToString())
                    {
                        FreeBoostsAvailable++;
                        continue;
                    }
                    if (boostFlaw.Ability == property.Name)
                    {
                        if (boostFlaw.IsBoost)
                        {
                            total += 2;
                        }
                        else
                        {
                            total -= 2;
                        }
                    }
                }
                property.SetValue(this, new AbilityScore(total, property.Name));
            }
        }
    }
}