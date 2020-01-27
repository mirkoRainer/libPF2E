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
    }
}