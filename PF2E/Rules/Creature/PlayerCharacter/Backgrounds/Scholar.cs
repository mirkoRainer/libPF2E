using System;
using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public class Scholar : IBackground
    {
        public string Name => this.GetType().Name;

        ICollection<AbilityScoreBoostFlaw> IBackground.AbilityBoosts => throw new NotImplementedException();
        public string SkillFeat => throw new NotImplementedException();
        public string TrainedSkill => throw new NotImplementedException();
        public string TrainedLoreSkill => throw new NotImplementedException();
    }
}