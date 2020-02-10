using System;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public class ProficiencyBasedNumber
    {
        public int Amount { get; }
        public Proficiency Proficiency { get; set; }
        public int ItemBonus { get; set; }
        public int ProficiencyBonus { get; }

        public ProficiencyBasedNumber(Proficiency proficiency, int level, int modifierBonus, bool isDC = false, int itemBonus = 0)
        {
            Proficiency = proficiency;
            ItemBonus = itemBonus;
            ProficiencyBonus = (int)Proficiency + level;
            Amount = ProficiencyBonus + ItemBonus + modifierBonus;
            if (isDC) Amount += 10;
        }
    }
}