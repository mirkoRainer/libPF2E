using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public interface IBackground
    {
        string Name { get; }
        ICollection<AbilityScoreBoostFlaw> AbilityBoosts { get; }
        string SkillFeat { get; }
        string TrainedSkill { get; }
        string TrainedLoreSkill { get; }
    }
}