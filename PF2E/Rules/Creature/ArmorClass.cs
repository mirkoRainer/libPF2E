using PF2E.Rules.Creature.PlayerCharacter;
using PF2E.Rules.Equipment;
using System;

namespace PF2E.Rules.Creature
{
    public class ArmorClass : ProficiencyBasedNumber
    {
        public int Total { get; }

        public ArmorClass(Proficiency proficiency,
            int level,
            int modifierBonus,
            Armor armor,
            bool isDC = false,
            int itemBonus = 0) : base(proficiency, level, modifierBonus, isDC)
        {
            Total = armor.ACBonus +
                Math.Min(armor.DexCap, modifierBonus) +
                ProficiencyBonus +
                10;
        }
    }
}