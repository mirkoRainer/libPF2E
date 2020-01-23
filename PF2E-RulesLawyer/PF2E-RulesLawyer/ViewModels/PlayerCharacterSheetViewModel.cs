using System;
using System.Collections.ObjectModel;
using PF2E_RulesLawyer.Models;
using PF2E_RulesLawyer.Models.Rules;
using PF2E_RulesLawyer.Models.Rules.Creature.PlayerCharacter;

namespace PF2E_RulesLawyer.ViewModels
{
    public class PlayerCharacterSheetViewModel : BaseViewModel
    {
        public PlayerCharacter PlayerCharacter { get; set; }

        // metadata

        public String CharacterName { get; set; }
        public String Ancestry { get; set; }
        public String Heritage { get; set; }
        public String Background { get; set; }
        public int Level { get; set; }
        public String PlayerName { get; set; }
        public String PcClass { get; set; }
        public String Size { get; set; }
        public String Alignment { get; set; }
        public String Traits { get; set; }
        public String Deity { get; set; }
        public int HeroPoints { get; set; }
        public int ExperiencePoints { get; set; }

        // Ability Scores

        public int Strength { get; set; }
        public int StrengthModifier { get; set; }
        public int Dexterity { get; set; }
        public int DexterityModifier { get; set; }
        public int Constitution { get; set; }
        public int ConstitutionModifier { get; set; }
        public int Intelligence { get; set; }
        public int IntelligenceModifier { get; set; }
        public int Wisdom { get; set; }
        public int WisModifier { get; set; }
        public int Charisma { get; set; }
        public int ChaModifier { get; set; }

        // Armor Class

        public int ArmorClass { get; set; }
        public int AC_CapDexBonus { get; set; }
        public int AC_ProficiencyBonus { get; set; }
        public Proficiency AC_ProficiencyLevel { get; set; }
        public int AC_ItemBonus { get; set; }
        public Proficiency UnarmoredProficiency { get; set; }
        public Proficiency LightArmorProficiency { get; set; }
        public Proficiency MediumArmorProficiency { get; set; }
        public Proficiency HeavyArmorProficiency { get; set; }
        public int ShieldBonus { get; set; }
        public int ShieldHardness { get; set; }
        public int ShieldMaxHitPoints { get; set; }
        public int ShieldBrokenThreshold { get; set; }
        public int ShieldCurrentHitPoints { get; set; }

        // Saving throws

        public int FortitudeSave { get; set; }
        public int ReflexSave { get; set; }
        public int WillSave { get; set; }
        public int FortitudeSaveProficiencyBonus { get; set; }
        public int ReflexSaveProficiencyBonus { get; set; }
        public int WillSaveProficiencyBonus { get; set; }
        public int FortitudeItemBonus { get; set; }
        public int ReflexItemBonus { get; set; }
        public int WillItemBonus { get; set; }
        public Proficiency FortitudeProficiency { get; set; }
        public Proficiency ReflexProficiency { get; set; }
        public Proficiency WillProficiency { get; set; }

        // Hit Points

        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int TemporaryHitPoints { get; set; }
        public int DyingValue { get; set; }
        public int WoundedValue { get; set; }
        public ObservableCollection<String> Resistances { get; set; }
        public ObservableCollection<String> Immunities { get; set; }
        public ObservableCollection<String> Conditions { get; set; }

        // Perception

        public int Perception { get; set; }
        public int PerceptionProficiencyBonus { get; set; }
        public Proficiency PerceptionProficiency { get; set; }
        public int PerceptionItemBonus { get; set; }
        public ObservableCollection<String> Senses { get; set; }

        // Class DC

        public int ClassDC { get; set; }
        public int ClassDCKeyAbilityModifier { get; set; }
        public int ClassDCProficiencyBonus { get; set; }
        public Proficiency ClassProficiency { get; set; }
        public int ClassDCItemBonus { get; set; }

        // Movement

        public int Speed { get; set; }
        public String MovementTypes { get; set; }

        // Melee Strikes

        public String MeleeStrikesDetails { get; set; }

        // Range Strikes

        public String RangeStrikesDetails { get; set; }

        // Weapon Proficiencies

        public Proficiency UnarmedProficiency { get; set; }
        public Proficiency SimpleWeaponProficiency { get; set; }
        public Proficiency MartialWeaponProficiency { get; set; }
        public Proficiency OtherWeaponProficiency { get; set; }

        // Skills

        public int Acrobatics { get; set; }
        public int Arcana { get; set; }
        public int Athletics { get; set; }
        public int Crafting { get; set; }
        public int Deception { get; set; }
        public int Diplomacy { get; set; }
        public int Intimidation { get; set; }
        public int Lore1 { get; set; }
        public String Lore1Topic { get; set; }
        public int Lore2 { get; set; }
        public String Lore2Topic { get; set; }
        public int Medicine { get; set; }
        public int Nature { get; set; }
        public int Occultism { get; set; }
        public int Performance { get; set; }
        public int Religion { get; set; }
        public int Society { get; set; }
        public int Stealth { get; set; }
        public int Survival { get; set; }
        public int Thievery { get; set; }

        // Languages

        public ObservableCollection<String> Languages { get; set; }

        public PlayerCharacterSheetViewModel()
        {
            CharacterName = "New Adventurer";
            PlayerCharacter = new PlayerCharacter(CharacterName);
        }

        public PlayerCharacterSheetViewModel(PlayerCharacter PC)
        {
            PlayerCharacter = PC ?? throw new ArgumentNullException(nameof(PC));
            CharacterName = PC.Name;
            Ancestry = PC.Ancestry.Name;
            Heritage = PC.Heritage;
            Background = PC.Background;
            Level = PC.Level;
            PlayerName = "Mike Snow";
            PcClass = "Rogue";
            Size = PC.Ancestry.Size.ToString();
            Alignment = "CG";
        }
    }
}