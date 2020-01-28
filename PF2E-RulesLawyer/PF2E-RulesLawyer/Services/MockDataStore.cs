using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PF2E_RulesLawyer.Models;
using PF2E_RulesLawyer.Models.PF2e_Rules.Creature.PlayerCharacter.Ancestries;
using PF2E.Rules;
using PF2E.Rules.Creature;
using PF2E.Rules.Creature.PlayerCharacter;

namespace PF2E_RulesLawyer.Services
{
    public class MockDataStore : IDataStore<PlayerCharacter>
    {
        private readonly List<PlayerCharacter> CreatedCharacters;

        public MockDataStore()
        {
            CreatedCharacters = new List<PlayerCharacter>()
            {
                new PlayerCharacter ("Croft")
                {
                    PlayerName = "Mike Snow",
                    PcClass = new Rogue(),
                    Ancestry = new Dwarf(),
                    Heritage = new AnvilDwarf(),
                    Background = new EmancipatedBackground(),
                    Size = new Dwarf().Size,
                    Alignment = Alignment.LN,
                    Traits = new List<Trait> { Trait.Dwarf, Trait.Humanoid },
                    Deity = "Tourag",
                    HeroPoints = 1,
                    ExperiencePoints = 10,
                    Strength = new AbilityScore(18, Ability.Strength),
                    Dexterity = new AbilityScore(12, Ability.Dexterity),
                    Constitution = new AbilityScore(16, Ability.Constitution),
                    Intelligence = new AbilityScore(10, Ability.Intelligence),
                    Wisdom = new AbilityScore(18, Ability.Wisdom),
                    Charisma = new AbilityScore(8, Ability.Charisma),
                    AC_ProficiencyBonus = 4,
                    AC_ProficiencyLevel = Proficiency.Expert,
                    AC_ItemBonus = 3,
                    UnarmoredProficiency = Proficiency.Trained,
                    LightArmorProficiency = Proficiency.Trained,
                    MediumArmorProficiency = Proficiency.Expert,
                    HeavyArmorProficiency = Proficiency.Expert,
                    ShieldBonus = 1,
                    ShieldMaxHitPoints = 10,
                    ShieldBrokenThreshold = 5,
                    ShieldHardness = 3,
                    ShieldCurrentHitPoints = 3,
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
            var oldItem = CreatedCharacters.Where((PlayerCharacter arg) => arg.Id == id).FirstOrDefault();
            CreatedCharacters.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<PlayerCharacter> GetItemAsync(string id)
        {
            return await Task.FromResult(CreatedCharacters.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<PlayerCharacter>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(CreatedCharacters);
        }
    }
}