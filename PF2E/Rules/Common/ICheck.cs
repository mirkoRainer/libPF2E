namespace PF2E.Rules
{
    internal interface ICheck
    {
        // 1. Roll a d20
        // 2. identify modifiers, bonuses, and penalties
        // 3. compare result to DC
        // 4. determine degree of success/failure
        Bonus[] Bonuses { get; set; }

        /*        Die Die { set; }
        */
        int AbilityModifier { get; set; }
        Penalty[] Penalties { get; set; }
    }
}