using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public class AbilityScoreArray
    {
        private List<AbilityScoreBoostFlaw> boosts;
        private List<AbilityScoreBoostFlaw> flaws;

        public AbilityScoreArray(List<AbilityScoreBoostFlaw> boosts, List<AbilityScoreBoostFlaw> flaws)
        {
            this.boosts = boosts;
            this.flaws = flaws;
        }

        public AbilityScore Strength { get; set; }
        public AbilityScore Dexterity { get; set; }
        public AbilityScore Constitution { get; set; }
        public AbilityScore Intelligence { get; set; }
        public AbilityScore Wisdom { get; set; }
        public AbilityScore Charisma { get; set; }

        private void CalculateAbilityScores(List<AbilityScoreBoostFlaw> boostsOrFlaw, bool isBoost)
        {
            var count = boostsOrFlaw.GroupBy(b => b)
                .Select(g => new
                {
                    key = g.Key,
                    count = g.Select(b => b).Count()
                })
                .ToList();
            Type tClass = this.GetType();
            PropertyInfo[] pClass = tClass.GetProperties();
            foreach ((PropertyInfo property, AbilityScore abilityScore) in from PropertyInfo property in pClass
                                                                           from abilityScore in
                                                                               from boost in count
                                                                               where property.Name == boost.key.ToString()
                                                                               let amount = AddOrSubtract(boost.count, isBoost)
                                                                               let abilityScore = new AbilityScore(10 + amount, boost.key.ToString())
                                                                               select abilityScore
                                                                           select (property, abilityScore))
            {
                property.SetValue(this, abilityScore);
            }
        }

        private int AddOrSubtract(int count, bool isBoost)
        {
            if (isBoost) return count * 2;
            return -(count * 2);
        }
    }
}