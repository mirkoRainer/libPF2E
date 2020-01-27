namespace PF2E.Rules.Creature
{
    public interface ISkill
    {
        Proficiency Proficiency { get; set; }
        AbilityScore KeyAbility { get; set; }
    }
}