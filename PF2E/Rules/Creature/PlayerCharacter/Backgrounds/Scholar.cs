using System;
using System.Collections.Generic;
using System.Text;

namespace PF2E.Rules.Creature.PlayerCharacter.Backgrounds
{
    internal class Scholar : IBackground
    {
        public string Name => throw new NotImplementedException();

        public AbilityScoreBoostFlaw[] AbilityBoosts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPcFeat SkillFeat { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Skill TrainedSkill { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        ICollection<AbilityScoreBoostFlaw> IBackground.AbilityBoosts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}