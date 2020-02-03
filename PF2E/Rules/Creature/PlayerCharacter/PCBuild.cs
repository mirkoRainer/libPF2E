using PF2E.Rules.Creature.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF2E.PF2E_Rules.Creature
{
    public class PCBuildABCs
    {
        public IAncestry Ancestry { get; set; }
        public IBackground Background { get; set; }
        public IPcClass PcClass { get; set; }
    }
}