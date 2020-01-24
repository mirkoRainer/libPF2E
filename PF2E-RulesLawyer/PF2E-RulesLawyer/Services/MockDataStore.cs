using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PF2E_RulesLawyer.Models;
using PF2E_RulesLawyer.Models.PF2e_Rules.Creature.PlayerCharacter.Ancestries;
using PF2E_RulesLawyer.Models.Rules;
using PF2E_RulesLawyer.Models.Rules.Creature;
using PF2E_RulesLawyer.Models.Rules.Creature.PlayerCharacter;

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
                    PcClass = "Rogue",
                    Ancestry = new Dwarf(),
                    Size = new Dwarf().Size,
                    Alignment = "CG",
                    Traits = "Dwarven, Humanoid",
                    Deity = "Tourag",
                    HeroPoints = 1,
                    ExperiencePoints = 10,
                    Strength = 18,
                    StrengthModifier = new AbilityModifier(
                        new AbilityScore(18, Ability.Strength))
                            .Amount,
                    Dexterity = 12,
                    DexterityModifier = new AbilityModifier(
                        new AbilityScore(12, Ability.Dexterity))
                            .Amount,
                    Constitution = 16,
                    ConstitutionModifier = new AbilityModifier(
                        new AbilityScore(16, Ability.Constitution))
                            .Amount,
                    Intelligence = 10,
                    IntelligenceModifier = new AbilityModifier(
                        new AbilityScore(10, Ability.Intelligence))
                            .Amount,
                    Wisdom = 18,
                    WisdomModifier = new AbilityModifier(
                        new AbilityScore(18, Ability.Wisdom))
                            .Amount,
                    Charisma = 8,
                    CharismaModifier = new AbilityModifier(
                        new AbilityScore(8, Ability.Charisma))
                            .Amount,
                    ArmorClass = 18,
                    AC_CapDexBonus = 1,
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