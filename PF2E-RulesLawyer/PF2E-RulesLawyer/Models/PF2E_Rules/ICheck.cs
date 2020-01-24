using PF2E_RulesLawyer.Models.Rules.Creature;

namespace PF2E_RulesLawyer.Models.Rules
{
    internal interface ICheck
    {
        // 1. Roll a d20
        // 2. identify modifiers, bonuses, and penalties
        // 3. compare result to DC
        // 4. determine degree of success/failure
        IBonus[] Bonuses { get; set; }

        /*        Die Die { set; }
        */
        AbilityModifier Modifier { get; set; }
        IPenalty[] Penalties { get; set; }
    }
}