using System;
using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public interface IAncestry
    {
        string Name { get; }
        int HitPoints { get; }
        Size Size { get; }
        int Speed { get; }
        Ability[] AbilityBoosts { get; }
        Ability[] AbilityFlaws { get; }
        Language[] Languages { get; }
        Trait[] Traits { get; }
        String[] SpecialAbilities { get; }
    }
}