namespace PF2E.Rules.Equipment
{
    public class Price
    {
        private int Copper;
        private int Silver;
        private int Gold;
        private int Platinum;

        public Price(int copper, int silver, int gold, int platinum)
        {
            Copper = copper;
            Silver = silver;
            Gold = gold;
            Platinum = platinum;
        }

        //This function assumes that each price is only going to be in terms of a single unit of currency
        //smartypan 10/21/19
        public string GetDisplayPrice()
        {
            if (Platinum > 0)
            {
                return Platinum.ToString() + " pp";
            }
            else if (Gold > 0)
            {
                return Gold.ToString() + " gp";
            }
            else if (Silver > 0)
            {
                return Silver.ToString() + " sp";
            }
            else if (Copper > 0)
            {
                return Copper.ToString() + " cp";
            }
            else
            {
                return "Free";
            }
        }
    }
}