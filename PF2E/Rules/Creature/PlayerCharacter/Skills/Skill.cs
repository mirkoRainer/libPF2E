using PF2E.Rules.Creature.PlayerCharacter;
using PF2E.Rules.Equipment;

namespace PF2E.Rules.Creature
{
    public class Skill : ProficiencyBasedNumber
    {
        public Skill(Proficiency proficiency,
            int level,
            int modifierBonus,
            bool isDC = false,
            int itemBonus = 0,
            Armor armor = null) : base(proficiency, level, modifierBonus, isDC, itemBonus)
        {
        }

        public string Name { get; set; }
        public string Descriptor { get; set; }
    }
}