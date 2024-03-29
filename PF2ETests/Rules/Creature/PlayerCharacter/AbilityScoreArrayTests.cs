﻿using System.Collections.Generic;
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
            var abilityScoreArray = new AbilityScoreArray(boostsAndFlaws);

            Assert.That(abilityScoreArray.Strength.Score, Is.EqualTo(14));
            Assert.That(abilityScoreArray.Dexterity.Score, Is.EqualTo(12));
            Assert.That(abilityScoreArray.Constitution.Score, Is.EqualTo(12));
            Assert.That(abilityScoreArray.Intelligence.Score, Is.EqualTo(10));
            Assert.That(abilityScoreArray.Wisdom.Score, Is.EqualTo(10));
            Assert.That(abilityScoreArray.Charisma.Score, Is.EqualTo(8));
        }

        [Test()]
        public void FreeBoostsAreCounted()
        {
            var abilityScoreArray = new AbilityScoreArray(boostsAndFlaws);
            Assert.That(abilityScoreArray.FreeBoostsAvailable, Is.EqualTo(1));
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
            var abilityScoreArray = new AbilityScoreArray(new List<AbilityScoreBoostFlaw>());
            abilityScoreArray.SetAbilityScore(new AbilityScore(14, Ability.Strength));
            abilityScoreArray.SetAbilityScore(new AbilityScore(14, Ability.Dexterity));
            abilityScoreArray.SetAbilityScore(new AbilityScore(14, Ability.Constitution));
            abilityScoreArray.SetAbilityScore(new AbilityScore(10, Ability.Intelligence));
            abilityScoreArray.SetAbilityScore(new AbilityScore(10, Ability.Wisdom));
            abilityScoreArray.SetAbilityScore(new AbilityScore(10, Ability.Charisma));
            abilityScoreArray.AddBoosts(boosts);

            Assert.That(abilityScoreArray.Strength.Score, Is.EqualTo(16));
            Assert.That(abilityScoreArray.Dexterity.Score, Is.EqualTo(16));
            Assert.That(abilityScoreArray.Constitution.Score, Is.EqualTo(16));
            Assert.That(abilityScoreArray.Intelligence.Score, Is.EqualTo(10));
            Assert.That(abilityScoreArray.Wisdom.Score, Is.EqualTo(10));
            Assert.That(abilityScoreArray.Charisma.Score, Is.EqualTo(12));
        }
    }
}