using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PF2E_RulesLawyer.Models;

namespace PF2E_RulesLawyer.Services
{
    public class MockDataStore : IDataStore<PlayerCharacter>
    {
        private readonly List<PlayerCharacter> items;

        public MockDataStore()
        {
            items = new List<PlayerCharacter>()
            {
                new PlayerCharacter { Id = Guid.NewGuid().ToString(), Name = "Croft", Ancestry="Dwarf" },
                new PlayerCharacter { Id = Guid.NewGuid().ToString(), Name = "Lyra", Ancestry="Dwarf" },
                new PlayerCharacter { Id = Guid.NewGuid().ToString(), Name = "Anais", Ancestry="This is an item description." },
                new PlayerCharacter { Id = Guid.NewGuid().ToString(), Name = "Frodo", Ancestry="This is an item description." },
            };
        }

        public async Task<bool> AddItemAsync(PlayerCharacter item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(PlayerCharacter item)
        {
            var oldItem = items.Where((PlayerCharacter arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((PlayerCharacter arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<PlayerCharacter> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<PlayerCharacter>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}