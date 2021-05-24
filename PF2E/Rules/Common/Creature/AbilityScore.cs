using System;

namespace PF2E.Rules.Creature
{
    public class AbilityScore
    {
        public int Score { get; private set; }
        public Ability Ability { get; private set; }

        public int Modifier { get; private set; }

        public AbilityScore(int score,
                            Ability ability)
        {
            Score = score;
            Ability = ability;
            double result = (double)(Score - 10) / 2;
            Modifier = (int)Math.Floor(result);
        }

        public AbilityScore(int score,
                            string ability)
        {
            Score = score;
            double result = (double)(Score - 10) / 2;
            Modifier = (int)Math.Floor(result);
            try
            {
                Ability = (Ability)System.Enum.Parse(typeof(Ability), ability);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("An ability string passed to the AbilityScore constructor was null. ");
            }
        }
    }
}