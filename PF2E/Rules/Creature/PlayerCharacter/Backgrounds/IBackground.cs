using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public interface IBackground
    {
        public string Name { get; }
        public List<AbilityScoreBoostFlaw> AbilityBoostOptions { get; }
        public AbilityScoreBoostFlaw AbilityScoreBoost { get; }
        public string SkillFeat { get; }
        public string TrainedSkill { get; }
        public string TrainedLoreSkill { get; }
    }
}