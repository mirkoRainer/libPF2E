using PF2E.PF2E_Rules;
using PF2E.Rules;
using PF2E.Rules.Creature;
using PF2E.Rules.Creature.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF2E_RulesLawyer.Models.PF2e_Rules.Creature.PlayerCharacter.Ancestries
{
    public readonly struct Gnome : IAncestry, IAoNItem
    {
        public string Name {
            get {
                return "Gnome";
            }
        }

        public int HitPoints {
            get {
                return 8;
            }
        }

        public Size Size {
            get {
                return Size.Small;
            }
        }

        public int Speed {
            get {
                return 25;
            }
        }

        public ICollection<AbilityScoreBoostFlaw> AbilityBoosts {
            get {
                return new AbilityScoreBoostFlaw[] {
                    new AbilityScoreBoostFlaw(true, Ability.Constitution),
                    new AbilityScoreBoostFlaw(true, Ability.Charisma),
                    new AbilityScoreBoostFlaw(true, Ability.Free) };
            }
        }

        public ICollection<AbilityScoreBoostFlaw> AbilityFlaws {
            get {
                return new AbilityScoreBoostFlaw[] { new AbilityScoreBoostFlaw(true, Ability.Strength) };
            }
        }

        public ICollection<Language> Languages {
            get {
                return new Language[] { Language.Gnomish, Language.Sylvan, Language.Common };
            }
        }

        public ICollection<Trait> Traits {
            get {
                return new Trait[] { Trait.Gnome, Trait.Humanoid };
            }
        }

        public ICollection<string> SpecialAbilities {
            get {
                return new string[] { "Low-Light Vision" };
            }
        }

        public Uri AoNUri => new Uri("http://2e.aonprd.com/Ancestries.aspx?ID=3");
    }
}