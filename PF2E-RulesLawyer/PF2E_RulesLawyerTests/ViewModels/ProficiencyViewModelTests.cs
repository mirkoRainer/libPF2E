using NUnit.Framework;
using PF2E.Rules;

namespace PF2E_RulesLawyer.ViewModels.Tests
{
    public class ProficiencyViewModelTests
    {
        [TestCase(
            Proficiency.Untrained,
            true, // untrained
            false, // trained
            false, // expert
            false, // master
            false)] // legendary
        [TestCase(
            Proficiency.Trained,
            false, // untrained
            true, // trained
            false, // expert
            false, // master
            false)] // legendary
        [TestCase(
            Proficiency.Expert,
            false, // untrained
            true, // trained
            true, // expert
            false, // master
            false)] // legendary
        [TestCase(
            Proficiency.Master,
            false, // untrained
            true, // trained
            true, // expert
            true, // master
            false)] // legendary
        [TestCase(
            Proficiency.Legendary,
            false, //untrained
            true, // trained
            true, // expert
            true, // master
            true)] // legendary
        public void UnTrainedProficiencyTranslatesToViewModel(
            Proficiency prof,
            bool untrained,
            bool trained,
            bool expert,
            bool master,
            bool legendary)
        {
            var profVm = new ProficiencyViewModel(prof);
            Assert.That(untrained, Is.EqualTo(profVm.IsUntrained));
            Assert.That(trained, Is.EqualTo(profVm.IsTrained));
            Assert.That(expert, Is.EqualTo(profVm.IsExpert));
            Assert.That(master, Is.EqualTo(profVm.IsMaster));
            Assert.That(legendary, Is.EqualTo(profVm.IsLegendary));
        }
    }
}