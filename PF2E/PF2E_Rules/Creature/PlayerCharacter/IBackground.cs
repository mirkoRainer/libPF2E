namespace PF2E.Rules.Creature.PlayerCharacter
{
    public interface IBackground
    {
        string Name { get; }
        AbilityScoreBoost[] AbilityBoosts { get; set; }
        IPcFeat SkillFeat { get; set; }
        Skill TrainedSkill { get; set; } // one should be Lore
        Skill TrainedLoreSkill { get; set; }
    }
}