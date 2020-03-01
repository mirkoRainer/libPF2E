using System.ComponentModel;
using Xamarin.Forms;
using PF2E_RulesLawyer.ViewModels;
using PF2E.Rules.Creature.PlayerCharacter;
using PF2E_RulesLawyer.Services;
using System;

namespace PF2E_RulesLawyer.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class PlayerCharacterSheetManualEditPage : ContentPage
    {
        private readonly PlayerCharacterSheetViewModel viewModel;

        public PlayerCharacterSheetManualEditPage()
        {
            viewModel = new PlayerCharacterSheetViewModel();
            InitializePage();
        }

        public PlayerCharacterSheetManualEditPage(PlayerCharacterSheetViewModel viewModel)
        {
            this.viewModel = viewModel;
            InitializePage();
        }

        private void InitializePage()
        {
            Title = "Character Sheet";
            BindingContext = viewModel;
            var playerNameEditor = new Editor
            {
                Placeholder = "Player Name",
                BackgroundColor = Color.White,
                Margin = new Thickness(5)
            };
            playerNameEditor.SetBinding(Editor.TextProperty, "PlayerName");
            var playerNameTitleLabel = new Label
            {
                Text = "Player Name",
                TextColor = Color.Black
            };

            var characterNameEditor = new Editor
            {
                Placeholder = "Character Name",
                BackgroundColor = Color.White,
                Margin = new Thickness(5)
            };
            characterNameEditor.SetBinding(Editor.TextProperty, "CharacterName");
            var characterNameTitleLabel = new Label
            {
                Text = "Character Name",
                TextColor = Color.Black
            };

            var ancestryTitleLabel = new Label { Text = "Ancestry:" };
            var ancestryPicker = new Picker { Title = "Select an Ancestry" };
            ancestryPicker.ItemsSource = viewModel.AncestriesList;
            ancestryPicker.SetBinding(Picker.SelectedItemProperty, "Ancestry");

            var backgroundTitleLabel = new Label { Text = "Background:" };
            var backgroundPicker = new Picker { Title = "Select a Background" };
            backgroundPicker.ItemsSource = viewModel.BackgroundsList;
            backgroundPicker.SetBinding(Picker.SelectedItemProperty, "Background");

            var classTitleLabel = new Label { Text = "Class:" };
            var classPicker = new Picker { Title = "Select a Class" };
            classPicker.ItemsSource = viewModel.ClassList;
            classPicker.SetBinding(Picker.SelectedItemProperty, "PcClass");

            var abilityScoreTitle = new Label { Text = "AbilityScores" };
            var strength = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    new Label { Text = "", BindingContext = viewModel.StrengthModifier, BackgroundColor = Color.White },
                    new StackLayout {
                        Children = {
                            new Label { Text = "STR"},
                            new Label { Text = "MODIFIER", FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)) }
                        }
                    },new StackLayout {
                        Children = {
                            new Label { Text = "STRENGTH"},
                            new Label { Text = "SCORE", FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)) }
                        }
                    },
                    new Label { Text = "", BindingContext = viewModel.Strength, BackgroundColor = Color.White }
                }
            };

            var saveCharacterButton = new Button
            {
                Text = "Save",
                TextColor = Color.White,
                BackgroundColor = Color.Green,
                Margin = new Thickness(5)
            };
            saveCharacterButton.SetBinding(Button.CommandProperty, "SaveCharacterCommand");

            var traitsCollectionView = new CollectionView();
            traitsCollectionView.SetBinding(CollectionView.ItemsSourceProperty, "TraitsCollection");

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    playerNameTitleLabel,
                    playerNameEditor,
                    characterNameTitleLabel,
                    characterNameEditor,
                    ancestryTitleLabel,
                    ancestryPicker,
                    backgroundTitleLabel,
                    backgroundPicker,
                    classTitleLabel,
                    classPicker,
                    abilityScoreTitle,
                    strength,
                    saveCharacterButton,
                }
            };
        }
    }
}