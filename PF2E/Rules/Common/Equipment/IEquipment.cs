namespace PF2E.Rules.Equipment
{
    public interface IEquipment
    {
        int Level { get; set; }
        Coins Price { get; set; }
        Bulk Bulk { get; set; }
    }
}