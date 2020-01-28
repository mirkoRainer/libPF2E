using PF2E.Rules.Creature;
using PF2E.Rules.Creature.PlayerCharacter;

namespace PF2E_RulesLawyer.Services
{
    public class Rogue : IPcClass
    {
        public string Name { get { return "Rogue"; } }
        public int HitPoints { get { return 8; } }
        public IPcFeat[] ClassFeats { get; set; }
        public string SubClass { get; set; }

        public void SetSubClass(string value)
        {
            throw new System.NotImplementedException();
        }
    }
}