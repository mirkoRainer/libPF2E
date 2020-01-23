namespace PF2E_RulesLawyer.Models.Rules.Equipment
{
    public interface IEquipment
    {
        int Level { get; set; }
        Price Price { get; set; }
        Bulk Bulk { get; set; }
    }
}