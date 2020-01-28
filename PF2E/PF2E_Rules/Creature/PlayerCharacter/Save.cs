using System;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public class Save
    {
        public int Amount { get; }
        public Proficiency Proficiency { get; set; }
        public int ItemBonus { get; set; }
        public int ProficiencyBonus { get; }

        public Save(Proficiency proficiency, int itemBonus, int level, int modifierBonus)
        {
            Proficiency = proficiency;
            ItemBonus = itemBonus;
            ProficiencyBonus = (int)Proficiency + level;
            Amount = ProficiencyBonus + ItemBonus + modifierBonus;
        }
    }
}