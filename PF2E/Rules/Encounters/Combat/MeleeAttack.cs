using System.Collections.Generic;

namespace PF2E.Rules.Encounters.Combat
{
    // Core Rulebook pg12
    public class MeleeAttack : ICheck
    {
        private List<Trait> Traits { get; set; }
        public Bonus[] Bonuses { get; set; }
        /*        public Die Die { set => new Die(20); }*/
        public int AbilityModifier { get; set; }
        public Penalty[] Penalties { get; set; }
    }
}