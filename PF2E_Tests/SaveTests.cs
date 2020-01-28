using PF2E.Rules;
using PF2E.Rules.Creature.PlayerCharacter;
using PF2E_RulesLawyer.ViewModels;
using System;
using Xunit;

namespace PF2E_Tests
{
    public class SaveTests
    {
        [Theory]
        [InlineData(
            Proficiency.Trained,
            0, // itemBonus
            1, // Level
            3, // modifier
            6  // expected
            )]
        public void NewSavesHaveCorrectPropertyCalculations(
            Proficiency prof,
            int itemBonus,
            int level,
            int modifier,
            int expected)
        {
            var save = new Save(prof, itemBonus, level, modifier);
            Assert.Equal(expected, save.Amount);
        }
    }
}