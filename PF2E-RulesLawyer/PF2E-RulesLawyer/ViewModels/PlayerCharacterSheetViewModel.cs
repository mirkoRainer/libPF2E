using System;
using System.Collections.ObjectModel;
using System.Text;
using PF2E_RulesLawyer.Models;
using PF2E.Rules;
using PF2E.Rules.Creature;
using PF2E.Rules.Creature.PlayerCharacter;
using Xamarin.Forms.Internals;
using System.Linq;
using System.Collections.Generic;

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
        }

        public String PcClass {
            get { return string.Format("{0} {1}", PlayerCharacter.PcClass.Name, PlayerCharacter.Level.ToString()); }
        }

        public String SubClass {
            get { return PlayerCharacter.PcClass.SubClass; }
        }

        public String Heritage {
            get { return PlayerCharacter.Heritage.Name; }
        }

        public String Background {
            get { return PlayerCharacter.Background.Name; }
        }

        public int Level {
            get { return PlayerCharacter.Level; }
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
        }
        private Alignment _selectedAlignment;
        public Alignment Alignment {
            get { return PlayerCharacter.Alignment; }
            set {
                PlayerCharacter.Alignment = value;
                OnPropertyChanged();
            }
        }
        public List<String> Alignments {
            get {
                return Enum.GetNames(typeof(Alignment)).Select(a => a).ToList();
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
        }

        public String Deity {
            get { return PlayerCharacter.Deity; }
            set {
                PlayerCharacter.Deity = value;
                OnPropertyChanged();
            }
        }

        public int HeroPoints {
            get { return PlayerCharacter.HeroPoints; }
            set {
                PlayerCharacter.HeroPoints = value;
                OnPropertyChanged();
            }
        }

        public int ExperiencePoints {
            get {
                return PlayerCharacter.ExperiencePoints;
            }
            set {
                PlayerCharacter.ExperiencePoints = value;
                OnPropertyChanged();
            }
        }

        #endregion metadataProperties

        #region AbilityScores

        public int Strength {
            get { return PlayerCharacter.Strength.Score; }
            set {
                PlayerCharacter.Strength = new AbilityScore(value, Ability.Strength); ;
                OnPropertyChanged();
            }
        }

        public int StrengthModifier {
            get { return PlayerCharacter.Strength.Modifier; }
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
        }

        #endregion AbilityScores

        #region ArmorClass

        public int ArmorClass { get { return PlayerCharacter.ArmorClass; } }
        public int AC_CapDexBonus { get { return PlayerCharacter.AC_CapDexBonus; } }
        public int AC_ProficiencyBonus { get { return PlayerCharacter.AC_ProficiencyBonus; } }

        public ProficiencyViewModel AC_ProficiencyLevel {
            get {
                return ConvertProficiencyToViewModel(PlayerCharacter.AC_ProficiencyLevel);
            }
        }

        private ProficiencyViewModel ConvertProficiencyToViewModel(Proficiency aC_ProficiencyLevel)
        {
            return new ProficiencyViewModel(aC_ProficiencyLevel);
        }

        public int AC_ItemBonus { get { return PlayerCharacter.AC_ItemBonus; } }

        public ProficiencyViewModel UnarmoredProficiency {
            get { return ConvertProficiencyToViewModel(PlayerCharacter.UnarmoredProficiency); }
        }

        public ProficiencyViewModel LightArmorProficiency {
            get { return ConvertProficiencyToViewModel(PlayerCharacter.LightArmorProficiency); }
        }

        public ProficiencyViewModel MediumArmorProficiency {
            get { return ConvertProficiencyToViewModel(PlayerCharacter.MediumArmorProficiency); }
        }

        public ProficiencyViewModel HeavyArmorProficiency {
            get { return ConvertProficiencyToViewModel(PlayerCharacter.HeavyArmorProficiency); }
        }

        public int ShieldBonus {
            get { return PlayerCharacter.ShieldBonus; }
        }

        public int ShieldHardness { get { return PlayerCharacter.ShieldHardness; } }
        public int ShieldMaxHitPoints { get { return PlayerCharacter.ShieldMaxHitPoints; } }
        public int ShieldBrokenThreshold { get { return PlayerCharacter.ShieldBrokenThreshold; } }

        public int ShieldCurrentHitPoints {
            get { return PlayerCharacter.ShieldCurrentHitPoints; }
            set {
                PlayerCharacter.ShieldCurrentHitPoints = value;
                OnPropertyChanged();
            }
        }

        #endregion ArmorClass

        #region SavingThrows

        public int FortitudeSave {
            get {
                return PlayerCharacter.FortitudeSave.Amount;
            }
        }

        public int FortitudeSaveProficiencyBonus {
            get {
                return PlayerCharacter.FortitudeSave.ProficiencyBonus;
            }
        }

        public int FortitudeItemBonus { get { return PlayerCharacter.FortitudeSave.ItemBonus; } }

        public ProficiencyViewModel FortitudeProficiency {
            get { return ConvertProficiencyToViewModel(PlayerCharacter.FortitudeProficiency); }
        }

        public int ReflexSave {
            get {
                return PlayerCharacter.ReflexSave.Amount;
            }
        }

        public int ReflexSaveProficiencyBonus {
            get {
                return PlayerCharacter.ReflexSave.ProficiencyBonus;
            }
        }

        public int ReflexItemBonus { get { return PlayerCharacter.ReflexSave.ItemBonus; } }

        public ProficiencyViewModel ReflexProficiency {
            get { return ConvertProficiencyToViewModel(PlayerCharacter.ReflexProficiency); }
        }

        public int WillSave {
            get {
                return PlayerCharacter.WillSave.Amount;
            }
        }

        public int WillSaveProficiencyBonus {
            get {
                return PlayerCharacter.WillSave.ProficiencyBonus;
            }
        }

        public int WillItemBonus { get { return PlayerCharacter.WillSave.ItemBonus; } }

        public ProficiencyViewModel WillProficiency {
            get { return ConvertProficiencyToViewModel(PlayerCharacter.WillProficiency); }
        }

        #endregion SavingThrows

        #region HitPoints

        public int MaxHitPoints {
            get {
                return PlayerCharacter.MaxHitPoints;
            }
        }

        public int CurrentHitPoints {
            get { return PlayerCharacter.CurrentHitPoints; }
            set {
                PlayerCharacter.CurrentHitPoints = value;
                OnPropertyChanged();
            }
        }

        public int TemporaryHitPoints {
            get { return PlayerCharacter.TemporaryHitPoints; }
            set {
                PlayerCharacter.TemporaryHitPoints = value;
                OnPropertyChanged();
            }
        }

        public int DyingValue {
            get { return PlayerCharacter.DyingValue; }
            set {
                PlayerCharacter.DyingValue = value;
                OnPropertyChanged();
            }
        }

        public int WoundedValue {
            get { return PlayerCharacter.WoundedValue; }
            set {
                PlayerCharacter.WoundedValue = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<String> Resistances {
            get {
                return new ObservableCollection<string>(PlayerCharacter.Resistances);
            }
            set {
                PlayerCharacter.Resistances = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<String> Immunities {
            get {
                return new ObservableCollection<string>(PlayerCharacter.Immunities);
            }
            set {
                PlayerCharacter.Immunities = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<String> Conditions {
            get {
                return new ObservableCollection<string>(PlayerCharacter.Conditions);
            }
            set {
                PlayerCharacter.Conditions = value;
                OnPropertyChanged();
            }
        }

        #endregion HitPoints

        #region Perception

        public int Perception { get { return PlayerCharacter.Perception; } }
        public int PerceptionProficiencyBonus { get { return PlayerCharacter.PerceptionProficiencyBonus; } }
        public ProficiencyViewModel PerceptionProficiency { get { return ConvertProficiencyToViewModel(PlayerCharacter.WillProficiency); } }
        public int PerceptionItemBonus { get { return PlayerCharacter.PerceptionItemBonus; } }
        public ObservableCollection<String> Senses { get { return new ObservableCollection<string>(PlayerCharacter.Senses); } }
        #endregion Perception

        #region ClassDC

        public int ClassDC { get { return PlayerCharacter.ClassDC; } }
        public int ClassDCKeyAbilityModifier {
            get { return PlayerCharacter.ClassDCKeyAbilityModifier; } }
        public int ClassDCProficiencyBonus {
            get { return PlayerCharacter.ClassDCProficiencyBonus; } }
        public ProficiencyViewModel ClassProficiency { get { return ConvertProficiencyToViewModel(PlayerCharacter.ClassProficiency); } }
        public int ClassDCItemBonus {
            get { return PlayerCharacter.ClassDCItemBonus; } }
        #endregion ClassDC

        #region movement
        public int Speed { get { return PlayerCharacter.Speed; } }
        public String MovementTypes { get { return PlayerCharacter.MovementTypes; } }
        #endregion movement

        #region strikes
        public String MeleeStrikesDetails { get { return PlayerCharacter.MeleeStrikesDetails; } }
        public String RangedStrikesDetails { get { return PlayerCharacter.RangedStrikesDetails; } }
        public ProficiencyViewModel UnarmedProficiency { get { return ConvertProficiencyToViewModel(PlayerCharacter.UnarmedProficiency); } }
        public ProficiencyViewModel SimpleWeaponProficiency { get { return ConvertProficiencyToViewModel(PlayerCharacter.SimpleWeaponProficiency); } }
        public ProficiencyViewModel MartialWeaponProficiency { get { return ConvertProficiencyToViewModel(PlayerCharacter.MartialWeaponProficiency); } }
        public ProficiencyViewModel OtherWeaponProficiency { get { return ConvertProficiencyToViewModel(PlayerCharacter.OtherWeaponProficiency); } }

        #endregion strikes
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

        public ObservableCollection<String> Languages {
            get {
                return new ObservableCollection<string>(PlayerCharacter.Languages);
            }
            set {
                PlayerCharacter.Languages = value;
                OnPropertyChanged();
            }
        }

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

        private void UpdateStringPCProperty(string value)
        {
            throw new NotImplementedException();
        }
        private void UpdateIntPCProperty(int value)
        {
            throw new NotImplementedException();
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