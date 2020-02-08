using PF2E.PF2E_Rules;
using PF2E.Rules;
using PF2E.Rules.Creature;
using PF2E.Rules.Creature.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF2E_RulesLawyer.Models.PF2e_Rules.Creature.PlayerCharacter.Ancestries
{
    public readonly struct Goblin : IAncestry, IAoNItem
    {
        public string Name {
            get {
                return "Goblin";
            }
        }

        public int HitPoints {
            get {
                return 6;
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
                    new AbilityScoreBoostFlaw(true, Ability.Dexterity),
                    new AbilityScoreBoostFlaw(true, Ability.Charisma),
                    new AbilityScoreBoostFlaw(true, Ability.Free) };
            }
        }

        public ICollection<AbilityScoreBoostFlaw> AbilityFlaws {
            get {
                return new AbilityScoreBoostFlaw[] { new AbilityScoreBoostFlaw(true, Ability.Wisdom) };
            }
        }

        public ICollection<Language> Languages {
            get {
                return new Language[] { Language.Goblin, Language.Common };
            }
        }

        public ICollection<Trait> Traits {
            get {
                return new Trait[] { Trait.Goblin, Trait.Humanoid };
            }
        }

        public ICollection<string> SpecialAbilities {
            get {
                return new string[] { "Darkvision" };
            }
        }

        public Uri AoNUri => new Uri("http://2e.aonprd.com/Ancestries.aspx?ID=4");
    }
}