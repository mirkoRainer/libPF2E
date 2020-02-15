using System;
using System.ComponentModel;
using Xamarin.Forms;
using PF2E.Rules.Creature.PlayerCharacter;

namespace PF2E_RulesLawyer.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewerSsSSssS
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public PlayerCharacter Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new PlayerCharacter(Ancestries.Dwarf,
                                       CharacterBackgrounds.Emancipated,
                                       PcClasses.Rogue);

            BindingContext = this;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}