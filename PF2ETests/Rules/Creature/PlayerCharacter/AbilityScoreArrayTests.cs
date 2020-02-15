using System.Collections.Generic;
using NUnit.Framework;
using PF2E.Rules.Creature;
using PF2E.Rules.Creature.PlayerCharacter;

namespace PF2ETests.Rules.Creature.PlayerCharacter
{
    [TestFixture()]
    public class AbilityScoreArrayTests
    {
        private List<AbilityScoreBoostFlaw> boostsAndFlaws = new List<AbilityScoreBoostFlaw>
            {
                new AbilityScoreBoostFlaw(true, Ability.Strength),
                new AbilityScoreBoostFlaw(true, Ability.Strength),
                new AbilityScoreBoostFlaw(true, Ability.Dexterity),
                new AbilityScoreBoostFlaw(true, Ability.Constitution),
                new AbilityScoreBoostFlaw(true, Ability.Free),
                new AbilityScoreBoostFlaw(false, Ability.Charisma)
            };

        [Test()]
        public void CalculationTest()
        {
            var asa = new AbilityScoreArray(boostsAndFlaws);

            Assert.That(asa.Strength.Score, Is.EqualTo(14));
            Assert.That(asa.Dexterity.Score, Is.EqualTo(12));
            Assert.That(asa.Constitution.Score, Is.EqualTo(12));
            Assert.That(asa.Intelligence.Score, Is.EqualTo(10));
            Assert.That(asa.Wisdom.Score, Is.EqualTo(10));
            Assert.That(asa.Charisma.Score, Is.EqualTo(8));
        }

        [Test()]
        public void AddBoostsTest()
        {
            List<AbilityScoreBoostFlaw> boosts = new List<AbilityScoreBoostFlaw>
            {
                new AbilityScoreBoostFlaw(true, Ability.Strength),
                new AbilityScoreBoostFlaw(true, Ability.Charisma),
                new AbilityScoreBoostFlaw(true, Ability.Dexterity),
                new AbilityScoreBoostFlaw(true, Ability.Constitution)
            };
            var asa = new AbilityScoreArray(new List<AbilityScoreBoostFlaw>())
            {
                Strength = new AbilityScore(14, Ability.Strength),
                Dexterity = new AbilityScore(14, Ability.Dexterity),
                Constitution = new AbilityScore(14, Ability.Constitution),
                Intelligence = new AbilityScore(10, Ability.Intelligence),
                Wisdom = new AbilityScore(10, Ability.Wisdom),
                Charisma = new AbilityScore(10, Ability.Charisma)
            };
            asa.AddBoosts(boosts);

            Assert.That(asa.Strength.Score, Is.EqualTo(16));
            Assert.That(asa.Dexterity.Score, Is.EqualTo(16));
            Assert.That(asa.Constitution.Score, Is.EqualTo(16));
            Assert.That(asa.Intelligence.Score, Is.EqualTo(10));
            Assert.That(asa.Wisdom.Score, Is.EqualTo(10));
            Assert.That(asa.Charisma.Score, Is.EqualTo(12));
        }
    }
}