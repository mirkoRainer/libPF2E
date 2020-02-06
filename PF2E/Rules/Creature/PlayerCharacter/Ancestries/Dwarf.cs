using PF2E.Rules;
using PF2E.Rules.Creature;
using PF2E.Rules.Creature.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF2E_RulesLawyer.Models.PF2e_Rules.Creature.PlayerCharacter.Ancestries
{
    public readonly struct Dwarf : IAncestry, IAoNItem
    {
        public string Name {
            get {
                return "Dwarf";
            }
        }

        public int HitPoints {
            get {
                return 10;
            }
        }

        public Size Size => Size.Medium;

        public int Speed {
            get {
                return 20;
            }
        }

        public ICollection<AbilityScoreBoostFlaw> AbilityBoosts {
            get {
                return new AbilityScoreBoostFlaw[] { AbilityScoreBoostFlaw.Constitution, AbilityScoreBoostFlaw.Wisdom, AbilityScoreBoostFlaw.Free };
            }
        }

        public ICollection<AbilityScoreBoostFlaw> AbilityFlaws {
            get {
                return new AbilityScoreBoostFlaw[] { AbilityScoreBoostFlaw.Charisma };
            }
        }

        public ICollection<Language> Languages {
            get {
                return new Language[] { Language.Dwarven, Language.Common };
            }
        }

        public ICollection<Trait> Traits {
            get {
                return new Trait[] { Trait.Dwarf, Trait.Humanoid };
            }
        }

        public ICollection<string> SpecialAbilities {
            get {
                return new string[] { "Darkvision", "Clan Dagger" };
            }
        }

        public Uri AoNUri { get { return new Uri("http://2e.aonprd.com/Ancestries.aspx?ID=1"); } }
    }
}