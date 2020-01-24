using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PF2E_RulesLawyer.Models;
using PF2E_RulesLawyer.ViewModels;
using PF2E_RulesLawyer.Models.PF2e_Rules.Creature.PlayerCharacter.Ancestries;

namespace PF2E_RulesLawyer.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class PlayerCharacterSheetPage : ContentPage
    {
        private readonly PlayerCharacterSheetViewModel viewModel;

        public PlayerCharacterSheetPage(PlayerCharacterSheetViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public PlayerCharacterSheetPage()
        {
            InitializeComponent();

            viewModel = new PlayerCharacterSheetViewModel(
                new PlayerCharacter("Croft"))
            {
                Title = "Character Sheet"
            };
            BindingContext = viewModel;
        }
    }
}