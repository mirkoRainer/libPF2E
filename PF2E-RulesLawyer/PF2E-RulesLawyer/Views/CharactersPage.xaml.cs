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
    public partial class CharactersPage : ContentPage
    {
        private CharactersViewModel viewModel;

        public CharactersPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CharactersViewModel();
        }

        private async void OnCharacterSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is PlayerCharacter character))
                return;

            await Navigation.PushAsync(new PlayerCharacterEditorPage(new PlayerCharacterSheetViewModel(character)));

            // Manually deselect item.
            CharactersListView.SelectedItem = null;
        }

        private async void AddCharacter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new PlayerCharacterEditorPage(new PlayerCharacterSheetViewModel())));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Characters.Count == 0)
                viewModel.LoadCharactersCommand.Execute(null);
        }
    }
}