using System;
using System.ComponentModel;
using Xamarin.Forms;
using PF2E_RulesLawyer.ViewModels;
using PF2E.Rules.Creature.PlayerCharacter;

namespace PF2E_RulesLawyer.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class PlayerCharacterEditorPage : ContentPage
    {
        private PlayerCharacterSheetViewModel viewModel;

        public PlayerCharacterEditorPage()
        {
            viewModel = new PlayerCharacterSheetViewModel();
            Title = "Player Character Editor";
            InitializeComponent();
        }

        public PlayerCharacterEditorPage(PlayerCharacterSheetViewModel viewModel)
        {
            this.viewModel = viewModel;
            Title = "Player Character Editor";
            InitializeComponent();
        }
    }
}