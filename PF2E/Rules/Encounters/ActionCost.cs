namespace PF2E.Rules.Encounters
{
    public class ActionCost
    {
        private int cost;

        public int Cost {
            get { return cost; }
            set {
                // limit the value of an action cost to a 3 action activity
                // or a zero cost free-action
                // or a -1 cost Reaction
                if (value < -1) { cost = -1; }
                if (value > 3) { cost = 3; }
                cost = value;
            }
        }
    }
}