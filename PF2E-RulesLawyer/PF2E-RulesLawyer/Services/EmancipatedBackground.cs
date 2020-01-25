using PF2E_RulesLawyer.Models.Rules.Creature;
using PF2E_RulesLawyer.Models.Rules.Creature.PlayerCharacter;

namespace PF2E_RulesLawyer.Services
{
    internal class EmancipatedBackground : IBackground
    {
        public string Name { get { return "Emancipated"; } }

        public AbilityScoreBoost[] AbilityBoosts { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IPcFeat SkillFeat { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public ISkill TrainedSkill { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public ISkill TrainedLoreSkill { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}