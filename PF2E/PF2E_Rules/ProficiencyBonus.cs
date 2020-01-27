namespace PF2E.Rules
{
    public class ProficiencyBonus : IBonus
    {
        #region IBonus

        public int Amount { get; }
        public string Type { get; }

        #endregion IBonus

        public ProficiencyBonus(int level, Proficiency proficiency)
        {
            Type = Bonustype.Proficiency.ToString("g");
            Amount = proficiency != Proficiency.Untrained
                ? level + (int)proficiency
                : 0;
        }
    }
}