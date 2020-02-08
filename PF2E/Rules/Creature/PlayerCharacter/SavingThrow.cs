using System;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public class SavingThrow
    {
        public int Amount { get; }
        public Proficiency Proficiency { get; set; }
        public int ItemBonus { get; set; }
        public int ProficiencyBonus { get; }

        public SavingThrow(Proficiency proficiency, int level, int modifierBonus, int itemBonus = 0)
        {
            Proficiency = proficiency;
            ItemBonus = itemBonus;
            ProficiencyBonus = (int)Proficiency + level;
            Amount = ProficiencyBonus + ItemBonus + modifierBonus;
        }
    }
}