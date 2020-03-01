using PF2E;
using PF2E.Rules.Creature.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF2E_RulesLawyer.Services
{
    public class MockDataStore : IDataStore<PlayerCharacter>
    {
        private readonly List<PlayerCharacter> CreatedCharacters;

        public MockDataStore()
        {
            CreatedCharacters = new List<PlayerCharacter>()
            {
                new PlayerCharacter (Ancestries.Dwarf, CharacterBackgrounds.Emancipated, PcClasses.Rogue)
                {
                    Id = new Guid(),
                    PlayerName = "Mike Snow"
                }
    };
        }

        public async Task<bool> AddItemAsync(PlayerCharacter item)
        {
            CreatedCharacters.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(PlayerCharacter item)
        {
            var oldItem = CreatedCharacters.Where((PlayerCharacter arg) => arg.Id == item.Id).FirstOrDefault();
            CreatedCharacters.Remove(oldItem);
            CreatedCharacters.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = CreatedCharacters.Where((PlayerCharacter arg) => arg.Id.ToString() == id).FirstOrDefault();
            CreatedCharacters.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<PlayerCharacter> GetItemAsync(string id)
        {
            return await Task.FromResult(CreatedCharacters.FirstOrDefault(s => s.Id.ToString() == id));
        }

        public async Task<IEnumerable<PlayerCharacter>> GetCharactersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(CreatedCharacters);
        }
    }
}