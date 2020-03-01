using NUnit.Framework;

namespace PF2E.Rules.Creature.PlayerCharacter.Tests
{
    [TestFixture()]
    public class SavingThrowTests
    {
        [Test()]
        [TestCase(
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
            var save = new ProficiencyBasedNumber(prof, level, modifier, false, itemBonus);
            Assert.That(expected, Is.EqualTo(save.Amount));
        }
    }
}