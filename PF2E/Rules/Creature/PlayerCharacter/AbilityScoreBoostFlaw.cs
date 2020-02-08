namespace PF2E.Rules.Creature.PlayerCharacter
{
    public class AbilityScoreBoostFlaw
    {
        public bool IsBoost { get; set; }
        public string Ability { get; set; }

        public AbilityScoreBoostFlaw(bool isBoost, Ability ability)
        {
            IsBoost = isBoost;
            Ability = ability.ToString();
        }
    }
}