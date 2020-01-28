using PF2E.Rules;
using PF2E_RulesLawyer.ViewModels;
using System;
using Xunit;

namespace PF2E_Tests
{
    public class ProficiencyViewModelTests
    {
        [Theory]
        [InlineData(
            Proficiency.Untrained,
            true, // untrained
            false, // trained
            false, // expert
            false, // master
            false)] // legendary
        [InlineData(
            Proficiency.Trained,
            false, // untrained
            true, // trained
            false, // expert
            false, // master
            false)] // legendary
        [InlineData(
        Proficiency.Expert,
            false, // untrained
            true, // trained
            true, // expert
            false, // master
            false)] // legendary
        [InlineData(
            Proficiency.Master,
            false, // untrained
            true, // trained
            true, // expert
            true, // master
            false)] // legendary
        [InlineData(
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
            Assert.Equal(untrained, profVm.IsUntrained);
            Assert.Equal(trained, profVm.IsTrained);
            Assert.Equal(expert, profVm.IsExpert);
            Assert.Equal(master, profVm.IsMaster);
            Assert.Equal(legendary, profVm.IsLegendary);
        }
    }
}