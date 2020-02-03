using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public interface IBackground
    {
        string Name { get; }
        ICollection<AbilityScoreBoostFlaw> AbilityBoosts { get; set; }
        IPcFeat SkillFeat { get; set; }
        Skill TrainedSkill { get; set; }

        Skill TrainedLoreSkill {
            get { return TrainedLoreSkill; }
            set { TrainedLoreSkill = value.Name == "Lore" ? value : throw new System.Exception("Lore skill for IBackground must have Name 'Lore'"); }
        }
    }
}