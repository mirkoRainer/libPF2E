namespace PF2E.Rules
{
    public class ProficiencyBonus : Bonus
    {

        public ProficiencyBonus(int level, Proficiency proficiency)
        {
            Type = Bonustype.Proficiency.ToString("g");
            Amount = proficiency != Proficiency.Untrained
                ? level + (int)proficiency
                : 0;
        }
    }
}