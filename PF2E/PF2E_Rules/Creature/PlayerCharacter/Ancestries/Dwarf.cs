using PF2E.Rules;
using PF2E.Rules.Creature;
using PF2E.Rules.Creature.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF2E_RulesLawyer.Models.PF2e_Rules.Creature.PlayerCharacter.Ancestries
{
    public readonly struct Dwarf : IAncestry
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

        public Size Size {
            get {
                return Size.Medium;
            }
        }

        public int Speed {
            get {
                return 20;
            }
        }

        public ICollection<Ability> AbilityBoosts {
            get {
                return new Ability[] { Ability.Constitution, Ability.Wisdom };
            }
        }

        public ICollection<Ability> AbilityFlaws {
            get {
                return new Ability[] { Ability.Charisma };
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
    }
}