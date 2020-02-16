using System.ComponentModel;
using Xamarin.Forms;
using PF2E_RulesLawyer.ViewModels;
using PF2E.Rules.Creature.PlayerCharacter;
using PF2E_RulesLawyer.Services;

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

            viewModel = new PlayerCharacterSheetViewModel()
            {
                Title = "Character Sheet"
            };
            BindingContext = viewModel;
        }
    }
}