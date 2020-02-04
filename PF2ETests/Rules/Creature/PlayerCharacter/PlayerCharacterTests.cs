using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter.Tests
{
    [TestFixture()]
    public class PlayerCharacterTests
    {
        [Test()]
        public void SetNewAlignmentTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void PlayerCharacterConstructorAbilityScoreCalculationTest()
        {
            var ancestry = new Mock<IAncestry>();
            var background = new Mock<IBackground>();
            var pcClass = new Mock<IPcClass>();

            ancestry.Setup(ancestry =>
                            ancestry.AbilityBoosts)
                    .Returns(new List<AbilityScoreBoostFlaw> { AbilityScoreBoostFlaw.Strength,
                                                               AbilityScoreBoostFlaw.Free });
            ancestry.Setup(a =>
                            a.AbilityFlaws)
                    .Returns(new List<AbilityScoreBoostFlaw> { AbilityScoreBoostFlaw.Charisma });

            background.Setup(b =>
                            b.AbilityBoosts)
                    .Returns(new List<AbilityScoreBoostFlaw> { AbilityScoreBoostFlaw.Constitution, AbilityScoreBoostFlaw.Strength });

            pcClass.Setup(c =>
                         c.KeyAbilityScore)
                    .Returns(AbilityScoreBoostFlaw.Dexterity);

            var pc = new PlayerCharacter(ancestry.Object, background.Object, pcClass.Object, 1);

            Assert.That(pc.Strength.Score, Is.EqualTo(14));
            Assert.That(pc.Dexterity.Score, Is.EqualTo(10));
            Assert.That(pc.Constitution.Score, Is.EqualTo(12));
            Assert.That(pc.Intelligence.Score, Is.EqualTo(10));
            Assert.That(pc.Wisdom.Score, Is.EqualTo(10));
            Assert.That(pc.Charisma.Score, Is.EqualTo(8));
        }
    }
}