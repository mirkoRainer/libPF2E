using System.Collections.Generic;

namespace PF2E.Rules.Equipment
{
    public class Armor
    {
        public string Name { get; set; }
        public ArmorCategory Category { get; set; }
        public int Level { get; set; }
        public Price Price { get; set; }
        public int ACBonus { get; set; }
        public int DexCap { get; set; }
        public Penalty CheckPenalty { get; set; }
        public Penalty SpeedPenalty { get; set; }
        public int StrengthRequirement { get; set; }
        public Bulk Bulk { get; set; }
        public ArmorGroup Group { get; set; }
        public IEnumerable<Trait> Traits { get; set; }
    }

    public enum ArmorGroup
    {
        Leather,
        Composite,
        Chain,
        Plate
    }

    public enum ArmorCategory
    {
        Unarmored,
        Light,
        Medium,
        Heavy
    }
}