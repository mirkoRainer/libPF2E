using PF2E.Rules.Creature;
using PF2E.Rules.Creature.PlayerCharacter;
using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter.Backgrounds
{
    public class EmancipatedBackground : IBackground
    {
        public string Name { get { return "Emancipated"; } }

        public ICollection<AbilityScoreBoostFlaw> AbilityBoosts { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string SkillFeat { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string TrainedSkill { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string TrainedLoreSkill { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}