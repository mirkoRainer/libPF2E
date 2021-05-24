using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public interface IAncestry
    {
        string Name { get; }
        int HitPoints { get; }
        Size Size { get; }
        int Speed { get; }
        ICollection<AbilityScoreBoostFlaw> AbilityBoosts { get; }
        ICollection<AbilityScoreBoostFlaw> AbilityFlaws { get; }
        ICollection<Language> Languages { get; }

        ICollection<Trait> Traits {
            get;
        }

        ICollection<string> SpecialAbilities { get; }
    }
}