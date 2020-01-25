namespace PF2E_RulesLawyer.Models.Rules.Creature.PlayerCharacter
{
    public interface IPcClass
    {
        string Name { get; }
        int HitPoints { get; }
        IPcFeat[] ClassFeats { get; set; }
        string SubClass { get; set; }

        void SetSubClass(string value);
    }
}