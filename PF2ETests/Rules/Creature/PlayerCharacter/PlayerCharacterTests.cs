using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter.Tests
{
    [TestFixture()]
    public class PlayerCharacterTests
    {
        private PlayerCharacter SetupMockedPlayerCharacter()
        {
            var mockAncestry = new Mock<IAncestry>();
            var mockBackground = new Mock<IBackground>();
            var mockPcClass = new Mock<IPcClass>();
            mockAncestry.Setup(x => x.Traits).Returns(new List<Trait>());
            return new PlayerCharacter();
        }

        [Test()]
        [TestCase("Dwarf")]
        [TestCase("Elf")]
        public void SetAncestryInvokesCorrectStaticMethod(string ancestryName)
        {
            var playerCharacter = SetupMockedPlayerCharacter();
            playerCharacter.SetAncestry(ancestryName);
            var ancestry =
                playerCharacter
                    .Ancestry;
            var result = ancestry.Name == ancestryName;
            TestContext.WriteLine(playerCharacter
                    .Ancestry
                    .ToString());
            Assert.IsTrue(result);
        }

        [Test()]
        [TestCase("Hooman")]
        public void SetAncestryThrowsErrorWithInvalidName(string invalidAncestryName)
        {
            var playerCharacter = SetupMockedPlayerCharacter();
            Assert.Throws<Exception>(delegate { playerCharacter.SetAncestry(invalidAncestryName); });
        }

        [Test()]
        [TestCase("Emancipated")]
        public void SetBackgroundInvokesCorrectStaticMethod(string backgroundName)
        {
            var playerCharacter = SetupMockedPlayerCharacter();
            playerCharacter.SetBackground(backgroundName);
            var background =
                playerCharacter
                    .Background;
            var result = background.Name == backgroundName;
            TestContext.WriteLine(playerCharacter
                    .Background
                    .ToString());
            Assert.IsTrue(result);
        }

        [Test()]
        [TestCase("Rgoue")]
        public void SetPcClassThrowsErrorWithInvalidName(string invalidClassName)
        {
            var playerCharacter = SetupMockedPlayerCharacter();
            Assert.Throws<Exception>(delegate { playerCharacter.SetClass(invalidClassName); });
        }

        [Test()]
        [TestCase("Rogue")]
        public void SetPcClassInvokesCorrectStaticMethod(string className)
        {
            var playerCharacter = SetupMockedPlayerCharacter();
            playerCharacter.SetClass(className);
            var pcClass =
                playerCharacter
                    .PcClass;
            var result = pcClass.Name == className;
            TestContext.WriteLine(playerCharacter
                    .PcClass
                    .ToString());
            Assert.IsTrue(result);
        }
    }
}