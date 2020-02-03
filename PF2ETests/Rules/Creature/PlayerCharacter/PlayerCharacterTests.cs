using NUnit.Framework;
using Moq;
using PF2E.Rules.Creature.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void PlayerCharacterTest()
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
                            b.)

            Assert.Fail();
        }
    }
}