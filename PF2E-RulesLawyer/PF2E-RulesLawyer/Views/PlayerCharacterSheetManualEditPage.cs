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

            /**
             * @todo Create option picker for Background Choice. Two options and then a Free choice.
             * @body Need to allow a user to select from the options available in a given background.
             * This is usually a choice between two and then a Free choice.
             */

            var classTitleLabel = new Label { Text = "Class:" };
            var classPicker = new Picker { Title = "Select a Class" };
            classPicker.ItemsSource = viewModel.ClassList;
            classPicker.SetBinding(Picker.SelectedItemProperty, "PcClass");

            var abilityScoreTitle = new Label { Text = "AbilityScores" };
            var strengthModifierLabel = new Label { Text = "", BackgroundColor = Color.White };
            strengthModifierLabel.SetBinding(Label.TextProperty, "StrengthModifier");
            var strengthScoreLabel = new Label { Text = "", BackgroundColor = Color.White };
            strengthScoreLabel.SetBinding(Label.TextProperty, "StrengthScore");

            var strengthLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    strengthModifierLabel,
                    new Label { Text = "MOD", FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)) },
                    new Label { Text = "STRENGTH"},
                    new Label { Text = "SCORE", FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)) },
                    strengthScoreLabel
                }
            };

            var dexterityModifierLabel = new Label { Text = "", BackgroundColor = Color.White };
            dexterityModifierLabel.SetBinding(Label.TextProperty, "DexterityModifier");
            var dexterityScoreLabel = new Label { Text = "", BackgroundColor = Color.White };
            dexterityScoreLabel.SetBinding(Label.TextProperty, "DexterityScore");
            var dexterityLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    dexterityModifierLabel,
                    new Label { Text = "MOD", FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)) },
                    new Label { Text = "DEXTERITY"},
                    new Label { Text = "SCORE", FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)) },
                    dexterityScoreLabel
                }
            };

            var constitutionModifierLabel = new Label { Text = "", BackgroundColor = Color.White };
            constitutionModifierLabel.SetBinding(Label.TextProperty, "ConstitutionModifier");
            var constitutionScoreLabel = new Label { Text = "", BackgroundColor = Color.White };
            constitutionScoreLabel.SetBinding(Label.TextProperty, "ConstitutionScore");
            var constitutionLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    constitutionModifierLabel,
                    new Label { Text = "MOD", FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)) },
                    new Label { Text = "CONSTITUTION"},
                    new Label { Text = "SCORE", FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)) },
                    constitutionScoreLabel
                }
            };

            var intelligenceModifierLabel = new Label { Text = "", BackgroundColor = Color.White };
            intelligenceModifierLabel.SetBinding(Label.TextProperty, "IntelligenceModifier");
            var intelligenceScoreLabel = new Label { Text = "", BackgroundColor = Color.White };
            intelligenceScoreLabel.SetBinding(Label.TextProperty, "IntelligenceScore");
            var intelligenceLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    intelligenceModifierLabel,
                    new Label { Text = "MOD", FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)) },
                    new Label { Text = "INTELLIGENCE"},
                    new Label { Text = "SCORE", FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)) },
                    intelligenceScoreLabel
                }
            };

            var wisdomModifierLabel = new Label { Text = "", BackgroundColor = Color.White };
            wisdomModifierLabel.SetBinding(Label.TextProperty, "WisdomModifier");
            var wisdomScoreLabel = new Label { Text = "", BackgroundColor = Color.White };
            wisdomScoreLabel.SetBinding(Label.TextProperty, "WisdomScore");
            var wisdomLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    wisdomModifierLabel,
                    new Label { Text = "MOD", FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)) },
                    new Label { Text = "WISDOM"},
                    new Label { Text = "SCORE", FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)) },
                    wisdomScoreLabel
                }
            };

            var charismaModifierLabel = new Label { Text = "", BackgroundColor = Color.White };
            charismaModifierLabel.SetBinding(Label.TextProperty, "CharismaModifier");
            var charismaScoreLabel = new Label { Text = "", BackgroundColor = Color.White };
            charismaScoreLabel.SetBinding(Label.TextProperty, "CharismaScore");
            var charismaLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    charismaModifierLabel,
                    new Label { Text = "MOD", FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)) },
                    new Label { Text = "CHARISMA"},
                    new Label { Text = "SCORE", FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)) },
                    charismaScoreLabel
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
                    classTitleLabel,
                    classPicker,
                    abilityScoreTitle,
                    strengthLayout,
                    dexterityLayout,
                    constitutionLayout,
                    intelligenceLayout,
                    wisdomLayout,
                    charismaLayout,
                    saveCharacterButton,
                }
            };
        }
    }
}