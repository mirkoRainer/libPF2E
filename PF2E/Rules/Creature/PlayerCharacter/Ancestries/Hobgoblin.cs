using System;
using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public readonly struct Hobgoblin : IAncestry, IAoNItem
    {
        public string Name {
            get {
                return "Hobgoblin";
            }
        }

        public int HitPoints {
            get {
                return 8;
            }
        }

        public Size Size {
            get {
                return Size.Medium;
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
                    new AbilityScoreBoostFlaw(true, Ability.Intelligence),
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
                return new Trait[] { Trait.Goblin, Trait.Humanoid, Trait.Uncommon };
            }
        }

        public ICollection<string> SpecialAbilities {
            get {
                return new string[] { "Darkvision" };
            }
        }

        public Uri AoNUri => new Uri("http://2e.aonprd.com/Ancestries.aspx?ID=13");
    }
}