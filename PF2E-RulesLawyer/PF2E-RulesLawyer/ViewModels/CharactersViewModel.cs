using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using PF2E_RulesLawyer.Views;
using PF2E.Rules.Creature.PlayerCharacter;

namespace PF2E_RulesLawyer.ViewModels
{
    public class CharactersViewModel : BaseViewModel
    {
        public ObservableCollection<PlayerCharacter> Characters { get; set; }
        public Command LoadCharactersCommand { get; set; }

        public CharactersViewModel()
        {
            Title = "Browse";
            Characters = new ObservableCollection<PlayerCharacter>();
            LoadCharactersCommand = new Command(async () => await ExecuteLoadCharactersCommand());

            MessagingCenter.Subscribe<PlayerCharacterSheetManualEditPage, PlayerCharacter>(this, "AddCharacter", async (obj, character) =>
            {
                var newCharacter = character as PlayerCharacter;
                Characters.Add(newCharacter);
                await DataStore.AddItemAsync(newCharacter);
            });
        }

        private async Task ExecuteLoadCharactersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Characters.Clear();
                var characters = await DataStore.GetCharactersAsync(true);
                foreach (var character in characters)
                {
                    Characters.Add(character);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}