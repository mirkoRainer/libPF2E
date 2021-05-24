using System;
using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public class Scholar : IBackground
    {
        public string Name => this.GetType().Name;

        public List<AbilityScoreBoostFlaw> AbilityBoostOptions {
            get => new List<AbilityScoreBoostFlaw>
                                                                                {
                                                                                    new AbilityScoreBoostFlaw(true, Ability.Intelligence),
                                                                                    new AbilityScoreBoostFlaw(true, Ability.Wisdom)
                                                                                };
        }

        public AbilityScoreBoostFlaw AbilityScoreBoost => new AbilityScoreBoostFlaw(true, Ability.Free);
        public string SkillFeat => throw new NotImplementedException();
        public string TrainedSkill => throw new NotImplementedException();
        public string TrainedLoreSkill => throw new NotImplementedException();
    }
}