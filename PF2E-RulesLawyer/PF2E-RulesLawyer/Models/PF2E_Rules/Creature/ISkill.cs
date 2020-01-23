namespace PF2E_RulesLawyer.Models.Rules.Creature
{
    public interface ISkill
    {
        Proficiency Proficiency { get; set; }
        AbilityScore KeyAbility { get; set; }
    }
}