using System;
using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    internal class Scholar : IBackground
    {
        public string Name => throw new NotImplementedException();

        public AbilityScoreBoostFlaw[] AbilityBoosts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Skill TrainedSkill { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string SkillFeat => throw new NotImplementedException();

        public string TrainedLoreSkill => throw new NotImplementedException();

        string IBackground.TrainedSkill => throw new NotImplementedException();

        ICollection<AbilityScoreBoostFlaw> IBackground.AbilityBoosts => throw new NotImplementedException();
    }
}