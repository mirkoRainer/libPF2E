using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using PF2E.Rules.Creature.PlayerCharacter;

namespace PF2ETests.Rules.Creature.PlayerCharacter
{
    [TestFixture()]
    public class AbilityScoreArrayTests
    {
        [Test()]
        public void AbilityScoreCalculationTest()
        {
            var boosts = new List<AbilityScoreBoostFlaw>
            {
                AbilityScoreBoostFlaw.Strength,
                AbilityScoreBoostFlaw.Strength,
                AbilityScoreBoostFlaw.Dexterity,
                AbilityScoreBoostFlaw.Constitution
            };
            var flaws = new List<AbilityScoreBoostFlaw>
            {
                AbilityScoreBoostFlaw.Charisma
            };

            var asa = new AbilityScoreArray(boosts, flaws);

            Assert.That(asa.Strength.Score, Is.EqualTo(14));
            Assert.That(asa.Dexterity.Score, Is.EqualTo(12));
            Assert.That(asa.Constitution.Score, Is.EqualTo(12));
            Assert.That(asa.Intelligence.Score, Is.EqualTo(10));
            Assert.That(asa.Wisdom.Score, Is.EqualTo(10));
            Assert.That(asa.Charisma.Score, Is.EqualTo(8));
        }
    }
}