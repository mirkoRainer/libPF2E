﻿using System;
using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public readonly struct Halfling : IAncestry, IAoNItem
    {
        public string Name {
            get {
                return "Halfling";
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
                    new AbilityScoreBoostFlaw(true, Ability.Wisdom),
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
                return new Language[] { Language.Halfling, Language.Common };
            }
        }

        public ICollection<Trait> Traits {
            get {
                return new Trait[] { Trait.Halfling, Trait.Humanoid };
            }
        }

        public ICollection<string> SpecialAbilities {
            get {
                return new string[] { "Keen Eyes" };
            }
        }

        public Uri AoNUri => new Uri("http://2e.aonprd.com/Ancestries.aspx?ID=5");
    }
}