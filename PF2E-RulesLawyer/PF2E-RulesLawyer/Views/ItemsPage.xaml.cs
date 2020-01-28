using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PF2E_RulesLawyer.Models;
using PF2E_RulesLawyer.Views;
using PF2E_RulesLawyer.ViewModels;
using PF2E.Rules.Creature.PlayerCharacter;

namespace PF2E_RulesLawyer.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        private ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            PlayerCharacter item = args.SelectedItem as PlayerCharacter;
            if (item == null)
                return;

            await Navigation.PushAsync(new PlayerCharacterSheetPage(new PlayerCharacterSheetViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new PlayerCharacterSheetPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}