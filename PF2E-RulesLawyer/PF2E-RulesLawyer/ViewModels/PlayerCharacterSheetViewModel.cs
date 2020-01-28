using System;
using System.Collections.ObjectModel;
using System.Text;
using PF2E_RulesLawyer.Models;
using PF2E.Rules;
using PF2E.Rules.Creature;
using PF2E.Rules.Creature.PlayerCharacter;
using Xamarin.Forms.Internals;

namespace PF2E_RulesLawyer.ViewModels
{
    public class PlayerCharacterSheetViewModel : BaseViewModel
    {
        public PlayerCharacter PlayerCharacter { get; set; }

        #region metadataProperties

        public String CharacterName {
            get { return PlayerCharacter.Name; }
            set {
                PlayerCharacter.Name = value;
                OnPropertyChanged();
            }
        }

        public String Ancestry {
            get { return PlayerCharacter.Ancestry.Name; }
            set {
                ChangeAncestry(value);
                OnPropertyChanged();
            }
        }

        public String PcClass {
            get { return string.Format("{0} {1}", PlayerCharacter.PcClass.Name, PlayerCharacter.Level.ToString()); }
            set {
                PlayerCharacter.PcClass = ChangeClass(value);
                OnPropertyChanged();
            }
        }

        public String SubClass {
            get { return PlayerCharacter.PcClass.SubClass; }
            set {
                PlayerCharacter.PcClass.SetSubClass(value);
                OnPropertyChanged();
            }
        }

        public String Heritage {
            get { return PlayerCharacter.Heritage.Name; }
            set {
                ChangeHeritage(value);
                OnPropertyChanged();
            }
        }

        public String Background {
            get { return PlayerCharacter.Background.Name; }
            set {
                ChangeBackground(value);
                OnPropertyChanged();
            }
        }

        public int Level {
            get { return PlayerCharacter.Level; }
            set {
                PlayerCharacter.Level = value;
                OnPropertyChanged();
            }
        }

        public String PlayerName {
            get { return PlayerCharacter.PlayerName; }
            set {
                PlayerCharacter.PlayerName = value;
                OnPropertyChanged();
            }
        }

        public String Size {
            get { return PlayerCharacter.Size.ToString().ToCharArray()[0].ToString(); }
            set {
                UpdatePCProperty(value);
                OnPropertyChanged();
            }
        }

        private void UpdatePCProperty(string value)
        {
            throw new NotImplementedException();
        }

        public String Alignment {
            get { return PlayerCharacter.Alignment.ToString(); }
            set {
                UpdatePCProperty(value);
                OnPropertyChanged();
            }
        }

        public String Traits {
            get {
                var traits = new StringBuilder();
                foreach (var trait in PlayerCharacter.Traits)
                {
                    traits.Append(string.Format("{0}, ", trait));
                }
                return traits.ToString();
            }
            set {
                UpdatePCProperty(value);
                OnPropertyChanged();
            }
        }

        public String Deity {
            get { return PlayerCharacter.Deity; }
            set {
                UpdatePCProperty(value);
                OnPropertyChanged();
            }
        }

        public int HeroPoints {
            get { return PlayerCharacter.HeroPoints; }
            set {
                UpdateIntPCProperty(value);
                OnPropertyChanged();
            }
        }

        private void UpdateIntPCProperty(int value)
        {
            throw new NotImplementedException();
        }

        public int ExperiencePoints {
            get { return PlayerCharacter.ExperiencePoints; }
            set {
                UpdateIntPCProperty(value);
                OnPropertyChanged();
            }
        }

        #endregion metadataProperties

        #region AbilityScores

        public int Strength {
            get { return PlayerCharacter.Strength.Score; }
            set {
                UpdateIntPCProperty(value);
                OnPropertyChanged();
            }
        }

        public int StrengthModifier {
            get { return PlayerCharacter.Strength.Modifier; }
            set {
                UpdateIntPCProperty(value);
                OnPropertyChanged();
            }
        }

        public int Dexterity {
            get { return PlayerCharacter.Dexterity.Score; }
            set {
                UpdateIntPCProperty(value);
                OnPropertyChanged();
            }
        }

        public int DexterityModifier {
            get { return PlayerCharacter.Dexterity.Modifier; }
            set {
                UpdateIntPCProperty(value);
                OnPropertyChanged();
            }
        }

        public int Constitution {
            get { return PlayerCharacter.Constitution.Score; }
            set {
                UpdateIntPCProperty(value);
                OnPropertyChanged();
            }
        }

        public int ConstitutionModifier {
            get { return PlayerCharacter.Constitution.Modifier; }
            set {
                UpdateIntPCProperty(value);
                OnPropertyChanged();
            }
        }

        public int Intelligence {
            get { return PlayerCharacter.Intelligence.Score; }
            set {
                UpdateIntPCProperty(value);
                OnPropertyChanged();
            }
        }

        public int IntelligenceModifier {
            get { return PlayerCharacter.Intelligence.Modifier; }
            set {
                UpdateIntPCProperty(value);
                OnPropertyChanged();
            }
        }

        public int Wisdom {
            get { return PlayerCharacter.Wisdom.Score; }
            set {
                UpdateIntPCProperty(value);
                OnPropertyChanged();
            }
        }

        public int WisdomModifier {
            get { return PlayerCharacter.Wisdom.Modifier; }
            set {
                UpdateIntPCProperty(value);
                OnPropertyChanged();
            }
        }

        public int Charisma {
            get { return PlayerCharacter.Charisma.Score; }
            set {
                UpdateIntPCProperty(value);
                OnPropertyChanged();
            }
        }

        public int CharismaModifier {
            get { return PlayerCharacter.Charisma.Modifier; }
            set {
                UpdateIntPCProperty(value);
                OnPropertyChanged();
            }
        }

        #endregion AbilityScores

        #region ArmorClass

        public int ArmorClass { get { return PlayerCharacter.ArmorClass; } }
        public int AC_CapDexBonus { get { return PlayerCharacter.AC_CapDexBonus; } }
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

        #endregion ArmorClass

        #region SavingThrows

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

        #endregion SavingThrows

        #region HitPoints

        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int TemporaryHitPoints { get; set; }
        public int DyingValue { get; set; }
        public int WoundedValue { get; set; }
        public ObservableCollection<String> Resistances { get; set; }
        public ObservableCollection<String> Immunities { get; set; }
        public ObservableCollection<String> Conditions { get; set; }

        #endregion HitPoints

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

        public String RangedStrikesDetails { get; set; }

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
            Title = "Character Sheet";
            PlayerCharacter = PC ?? new PlayerCharacter("Salazat");
        }

        private void ChangeAncestry(string value)
        {
            throw new NotImplementedException();
        }

        private IPcClass ChangeClass(string value)
        {
            throw new NotImplementedException();
        }

        private void ChangeHeritage(string value)
        {
            throw new NotImplementedException();
        }

        private void ChangeBackground(string value)
        {
            throw new NotImplementedException();
        }
    }
}