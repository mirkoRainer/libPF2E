using PF2E.Rules.Creature;
using PF2E.Rules.Creature.PlayerCharacter;
using System.Collections.Generic;

namespace PF2E_RulesLawyer.Services
{
    public class EmancipatedBackground : IBackground
    {
        public string Name { get { return "Emancipated"; } }

        public ICollection<AbilityScoreBoostFlaw> AbilityBoosts { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IPcFeat SkillFeat { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Skill TrainedSkill { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Skill TrainedLoreSkill { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}