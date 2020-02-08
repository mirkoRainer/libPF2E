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

        public AbilityScore Strength { get; set; }
        public AbilityScore Dexterity { get; set; }
        public AbilityScore Constitution { get; set; }
        public AbilityScore Intelligence { get; set; }
        public AbilityScore Wisdom { get; set; }
        public AbilityScore Charisma { get; set; }

        private readonly PropertyInfo[] propertiesOfThisClass;

        public void AddBoosts(List<AbilityScoreBoostFlaw> boosts)
        {
            foreach (var property in propertiesOfThisClass)
            {
                foreach (var boost in boosts)
                {
                    if (boost.Ability == property.Name)
                    {
                        AbilityScore current = (AbilityScore)property.GetValue(this);
                        property.SetValue(this, new AbilityScore(current.Score + 2, property.Name));
                    }
                }
            }
        }

        private void CalculateAbilityScores(List<AbilityScoreBoostFlaw> boostsAndFlaws)
        {
            foreach (var property in propertiesOfThisClass)
            {
                int total = 10;
                foreach (var boostFlaw in boostsAndFlaws)
                {
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