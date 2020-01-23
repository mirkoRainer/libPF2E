namespace PF2E_RulesLawyer.Models.Rules.Creature.PlayerCharacter
{
    public interface IPcClass
    {
        string Name { get; set; }
        int HitPoints { get; set; }
        IPcFeat[] ClassFeats { get; set; }
    }
}