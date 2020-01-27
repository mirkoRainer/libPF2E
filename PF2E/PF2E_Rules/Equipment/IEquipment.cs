namespace PF2E.Rules.Equipment
{
    public interface IEquipment
    {
        int Level { get; set; }
        Price Price { get; set; }
        Bulk Bulk { get; set; }
    }
}