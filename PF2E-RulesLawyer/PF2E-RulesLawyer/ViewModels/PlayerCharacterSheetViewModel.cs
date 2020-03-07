using System;
using System.Collections.ObjectModel;
using System.Text;
using PF2E;
using PF2E.Rules;
using PF2E.Rules.Creature;
using PF2E.Rules.Creature.PlayerCharacter;
using System.Linq;
using PF2E_RulesLawyer.Services;
using Xamarin.Forms;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PF2E_RulesLawyer.ViewModels
{
    public class PlayerCharacterSheetViewModel : BaseViewModel
    {
        private PlayerCharacter playerCharacter { get; set; }

        private bool isEditing = true;
        public bool IsEditing { get => isEditing; set => SetProperty<bool>(ref isEditing, value); }

        #region Page1

        #region metadataProperties

        private String characterName = String.Empty;

        public String CharacterName {
            get => characterName;
            set {
                playerCharacter.Name = value;
                SetProperty<String>(ref characterName, value);
            }
        }

        private List<String> ancestriesList = PF2eCoreUtils.GetListOfAncestries();

        public ObservableCollection<String> AncestriesList {
            get => new ObservableCollection<String>(ancestriesList);
        }

        private string ancestry = String.Empty;

        public string Ancestry {
            get => ancestry;
            set {
                playerCharacter.SetAncestry(value);
                SetProperty<string>(ref ancestry, value);
            }
        }

        private List<String> backgroundsList = PF2eCoreUtils.GetListOfBackgrounds();

        public ObservableCollection<String> BackgroundsList {
            get => new ObservableCollection<string>(backgroundsList);
        }

        private String background = String.Empty;

        public String Background {
            get => background;
            set {
                SetProperty<String>(ref background, value);
                playerCharacter.SetBackground(value);
                backgroundAbilityChoices = playerCharacter.GetBackgroundAbilityChoices();
                OnPropertyChanged(nameof(BackgroundAbilityChoices));
            }
        }

        private List<string> backgroundAbilityChoices = new List<string>();

        public ObservableCollection<String> BackgroundAbilityChoices {
            get {
                return new ObservableCollection<string>(backgroundAbilityChoices);
            }
            set {
                SetProperty<List<string>>(ref backgroundAbilityChoices, value.ToList());
            }
        }

        private String backgroundAbilityChoice;

        public String BackgroundAbilityChoice {
            get => backgroundAbilityChoice;
            set {
                playerCharacter.SetBackgroundAbility(value);
                SetProperty<string>(ref backgroundAbilityChoice, value);
            }
        }

        public ObservableCollection<String> ClassList {
            get {
                return new ObservableCollection<string>(PF2eCoreUtils.GetListOfClasses());
            }
        }

        private String pcClass;

        public String PcClass {
            get => pcClass;
            set {
                SetProperty<String>(ref pcClass, value);
                playerCharacter.SetClass(value);
            }
        }

        public String SubClass {
            get { return CheckNullString(playerCharacter.SubClass); }
        }

        public String Heritage {
            get { return CheckNullString(playerCharacter.Heritage.Name); }
        }

        public int Level {
            get { return playerCharacter.Level > 0 ? playerCharacter.Level : 1; }
        }

        private string playerName;

        public String PlayerName {
            get => playerName;
            set {
                playerName = CheckNullString(value);
                playerCharacter.PlayerName = CheckNullString(value);
                OnPropertyChanged();
            }
        }

        public Command SaveCharacterCommand { get; }

        public String Size {
            get { return CheckNullString(playerCharacter.Size.ToString()); }
        }

        public String Alignment {
            get { return CheckNullString(playerCharacter.Alignment.ToString()); }
            set {
                playerCharacter.SetNewAlignment(value);
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Trait> Traits { get; set; }

        public String Deity {
            get { return CheckNullString(playerCharacter.Deity); }
            set {
                playerCharacter.Deity = value;
                OnPropertyChanged();
            }
        }

        public int HeroPoints {
            get { return playerCharacter.HeroPoints; }
            set {
                playerCharacter.HeroPoints = value;
                OnPropertyChanged();
            }
        }

        public int ExperiencePoints {
            get {
                return playerCharacter.ExperiencePoints;
            }
            set {
                playerCharacter.ExperiencePoints = value;
                OnPropertyChanged();
            }
        }

        #endregion metadataProperties

        #region AbilityScores

        public List<int> AbilityScoreRange { get => PF2eCoreUtils.GetAbilityScoreRange(); }

        private string CreateAbilityModifierString(int modifier)
        {
            if (modifier <= 0)
            {
                return $"{modifier}";
            }
            else
            {
                return $"+{modifier}";
            }
        }

        private int strengthScore = 0;

        public int StrengthScore {
            get {
                if (playerCharacter.AbilityScores.Strength == null)
                {
                    return 10;
                }
                strengthScore = playerCharacter.AbilityScores.Strength.Score;
                return strengthScore;
            }
            set {
                playerCharacter.AbilityScores.Strength = new AbilityScore(value, Ability.Strength);
                strengthModifier = playerCharacter.AbilityScores.Strength.Modifier;
                SetProperty<int>(ref strengthScore, value);
                OnPropertyChanged(nameof(StrengthModifierString));
            }
        }

        private int strengthModifier { get; set; }

        public string StrengthModifierString {
            get {
                return CreateAbilityModifierString(modifier: strengthModifier);
            }
        }

        private int dexterityScore = 0;

        public int DexterityScore {
            get {
                if (playerCharacter.AbilityScores.Dexterity == null)
                {
                    return 10;
                }
                dexterityScore = playerCharacter.AbilityScores.Dexterity.Score;
                return dexterityScore;
            }
            set {
                playerCharacter.AbilityScores.Dexterity = new AbilityScore(value, Ability.Dexterity);
                dexterityModifier = playerCharacter.AbilityScores.Dexterity.Modifier;
                SetProperty<int>(ref dexterityScore, value);
                OnPropertyChanged(nameof(DexterityModifierString));
            }
        }

        private int dexterityModifier { get; set; }

        public string DexterityModifierString {
            get {
                return CreateAbilityModifierString(modifier: dexterityModifier);
            }
        }

        private int constitutionScore = 0;

        public int ConstitutionScore {
            get {
                if (playerCharacter.AbilityScores.Constitution == null)
                {
                    return 10;
                }
                constitutionScore = playerCharacter.AbilityScores.Constitution.Score;
                return constitutionScore;
            }
            set {
                playerCharacter.AbilityScores.Constitution = new AbilityScore(value, Ability.Constitution);
                constitutionModifier = playerCharacter.AbilityScores.Constitution.Modifier;
                SetProperty<int>(ref constitutionScore, value);
                OnPropertyChanged(nameof(ConstitutionModifierString));
            }
        }

        private int constitutionModifier { get; set; }

        public string ConstitutionModifierString {
            get {
                return CreateAbilityModifierString(modifier: constitutionModifier);
            }
        }

        private int intelligenceScore = 0;

        public int IntelligenceScore {
            get {
                if (playerCharacter.AbilityScores.Intelligence == null)
                {
                    return 10;
                }
                intelligenceScore = playerCharacter.AbilityScores.Intelligence.Score;
                return intelligenceScore;
            }
            set {
                playerCharacter.AbilityScores.Intelligence = new AbilityScore(value, Ability.Intelligence);
                intelligenceModifier = playerCharacter.AbilityScores.Intelligence.Modifier;
                SetProperty<int>(ref intelligenceScore, value);
                OnPropertyChanged(nameof(IntelligenceModifierString));
            }
        }

        private int intelligenceModifier { get; set; }

        public string IntelligenceModifierString {
            get {
                return CreateAbilityModifierString(modifier: intelligenceModifier);
            }
        }

        private int wisdomScore = 0;

        public int WisdomScore {
            get {
                if (playerCharacter.AbilityScores.Wisdom == null)
                {
                    return 10;
                }
                wisdomScore = playerCharacter.AbilityScores.Wisdom.Score;
                return wisdomScore;
            }
            set {
                playerCharacter.AbilityScores.Wisdom = new AbilityScore(value, Ability.Wisdom);
                wisdomModifier = playerCharacter.AbilityScores.Wisdom.Modifier;
                SetProperty<int>(ref wisdomScore, value);
                OnPropertyChanged(nameof(WisdomModifierString));
            }
        }

        private int wisdomModifier { get; set; }

        public string WisdomModifierString {
            get {
                return CreateAbilityModifierString(modifier: wisdomModifier);
            }
        }

        private int charismaScore = 0;

        public int CharismaScore {
            get {
                if (playerCharacter.AbilityScores.Charisma == null)
                {
                    return 10;
                }
                charismaScore = playerCharacter.AbilityScores.Charisma.Score;
                return charismaScore;
            }
            set {
                playerCharacter.AbilityScores.Charisma = new AbilityScore(value, Ability.Charisma);
                charismaModifier = playerCharacter.AbilityScores.Charisma.Modifier;
                SetProperty<int>(ref charismaScore, value);
                OnPropertyChanged(nameof(CharismaModifierString));
            }
        }

        private int charismaModifier { get; set; }

        public string CharismaModifierString {
            get {
                return CreateAbilityModifierString(modifier: charismaModifier);
            }
        }

        #endregion AbilityScores

        #region ArmorClass

        public int ArmorClass => playerCharacter.ArmorClass.Amount;
        public int ACDexCap { get { return playerCharacter.Armor.DexCap; } }

        public ProficiencyViewModel AC_ProficiencyLevel {
            get {
                var prof = ProficiencyNullCheck(playerCharacter.ArmorClass.Proficiency);
                return ConvertProficiencyToViewModel(playerCharacter.ArmorClass.Proficiency);
            }
        }

        private Proficiency ProficiencyNullCheck(Proficiency proficiency)
        {
            throw new NotImplementedException();
        }

        private ProficiencyViewModel ConvertProficiencyToViewModel(Proficiency aC_ProficiencyLevel)
        {
            return new ProficiencyViewModel(aC_ProficiencyLevel);
        }

        public int AC_ItemBonus { get { return playerCharacter.Armor.ACBonus; } }

        public ProficiencyViewModel UnarmoredProficiency {
            get { return ConvertProficiencyToViewModel(playerCharacter.UnarmoredProficiency); }
        }

        public ProficiencyViewModel LightArmorProficiency {
            get { return ConvertProficiencyToViewModel(playerCharacter.LightArmorProficiency); }
        }

        public ProficiencyViewModel MediumArmorProficiency {
            get { return ConvertProficiencyToViewModel(playerCharacter.MediumArmorProficiency); }
        }

        public ProficiencyViewModel HeavyArmorProficiency {
            get { return ConvertProficiencyToViewModel(playerCharacter.HeavyArmorProficiency); }
        }

        public int ShieldBonus {
            get { return playerCharacter.ShieldBonus; }
        }

        public int ShieldHardness { get { return playerCharacter.ShieldHardness; } }
        public int ShieldMaxHitPoints { get { return playerCharacter.ShieldMaxHitPoints; } }
        public int ShieldBrokenThreshold { get { return playerCharacter.ShieldBrokenThreshold; } }

        public int ShieldCurrentHitPoints {
            get { return playerCharacter.ShieldCurrentHitPoints; }
            set {
                playerCharacter.ShieldCurrentHitPoints = value;
                OnPropertyChanged();
            }
        }

        #endregion ArmorClass

        #region SavingThrows

        public int FortitudeSave {
            get {
                return playerCharacter.FortitudeSave.Amount;
            }
        }

        public int FortitudeSaveProficiencyBonus {
            get {
                return playerCharacter.FortitudeSave.ProficiencyBonus;
            }
        }

        public int FortitudeItemBonus { get { return playerCharacter.FortitudeSave.ItemBonus; } }

        public ProficiencyViewModel FortitudeProficiency {
            get { return ConvertProficiencyToViewModel(playerCharacter.FortitudeSave.Proficiency); }
        }

        public int ReflexSave {
            get {
                return playerCharacter.ReflexSave.Amount;
            }
        }

        public int ReflexSaveProficiencyBonus {
            get {
                return playerCharacter.ReflexSave.ProficiencyBonus;
            }
        }

        public int ReflexItemBonus { get { return playerCharacter.ReflexSave.ItemBonus; } }

        public ProficiencyViewModel ReflexProficiency {
            get { return ConvertProficiencyToViewModel(playerCharacter.ReflexSave.Proficiency); }
        }

        public int WillSave {
            get {
                return playerCharacter.WillSave.Amount;
            }
        }

        public int WillSaveProficiencyBonus {
            get {
                return playerCharacter.WillSave.ProficiencyBonus;
            }
        }

        public int WillItemBonus { get { return playerCharacter.WillSave.ItemBonus; } }

        public ProficiencyViewModel WillProficiency {
            get { return ConvertProficiencyToViewModel(playerCharacter.WillSave.Proficiency); }
        }

        #endregion SavingThrows

        #region HitPoints

        public int MaxHitPoints {
            get {
                return playerCharacter.MaxHitPoints;
            }
        }

        public int CurrentHitPoints {
            get { return playerCharacter.CurrentHitPoints; }
            set {
                playerCharacter.CurrentHitPoints = value;
                OnPropertyChanged();
            }
        }

        public int TemporaryHitPoints {
            get { return playerCharacter.TemporaryHitPoints; }
            set {
                playerCharacter.TemporaryHitPoints = value;
                OnPropertyChanged();
            }
        }

        public int DyingValue {
            get { return playerCharacter.DyingValue; }
            set {
                playerCharacter.DyingValue = value;
                OnPropertyChanged();
            }
        }

        public int WoundedValue {
            get { return playerCharacter.WoundedValue; }
            set {
                playerCharacter.WoundedValue = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<String> Resistances {
            get {
                return new ObservableCollection<string>(playerCharacter.Resistances);
            }
            set {
                playerCharacter.Resistances = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<String> Immunities {
            get {
                return new ObservableCollection<string>(playerCharacter.Immunities);
            }
            set {
                playerCharacter.Immunities = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<String> Conditions {
            get {
                return new ObservableCollection<string>(playerCharacter.Conditions);
            }
            set {
                playerCharacter.Conditions = value;
                OnPropertyChanged();
            }
        }

        #endregion HitPoints

        #region Perception

        public int Perception { get { return playerCharacter.Perception.Amount; } }
        public int PerceptionProficiencyBonus { get { return playerCharacter.Perception.ProficiencyBonus; } }
        public ProficiencyViewModel PerceptionProficiency { get { return ConvertProficiencyToViewModel(playerCharacter.Perception.Proficiency); } }
        public int PerceptionItemBonus { get { return playerCharacter.Perception.ItemBonus; } }
        public ObservableCollection<String> Senses { get { return new ObservableCollection<string>(playerCharacter.Senses); } }

        #endregion Perception

        #region ClassDC

        public int ClassDC { get { return playerCharacter.ClassDC.Amount; } }

        public int ClassDCKeyAbilityModifier {
            get { return playerCharacter.PcClass.GetKeyAbilityScoreModifier(); }
        }

        public int ClassDCProficiencyBonus {
            get { return playerCharacter.ClassDC.ProficiencyBonus; }
        }

        public ProficiencyViewModel ClassProficiency { get { return ConvertProficiencyToViewModel(playerCharacter.ClassDC.Proficiency); } }

        public int ClassDCItemBonus {
            get { return playerCharacter.ClassDC.ItemBonus; }
        }

        #endregion ClassDC

        #region movement

        public int Speed { get { return playerCharacter.Speed; } }
        public String MovementTypes { get { return playerCharacter.MovementTypes; } }

        #endregion movement

        #region strikes

        public String MeleeStrikesDetails { get { return playerCharacter.MeleeStrikesDetails; } }
        public String RangedStrikesDetails { get { return playerCharacter.RangedStrikesDetails; } }
        public ProficiencyViewModel UnarmedProficiency { get { return ConvertProficiencyToViewModel(playerCharacter.UnarmedProficiency); } }
        public ProficiencyViewModel SimpleWeaponProficiency { get { return ConvertProficiencyToViewModel(playerCharacter.SimpleWeaponProficiency); } }
        public ProficiencyViewModel MartialWeaponProficiency { get { return ConvertProficiencyToViewModel(playerCharacter.MartialWeaponProficiency); } }
        public ProficiencyViewModel OtherWeaponProficiency { get { return ConvertProficiencyToViewModel(playerCharacter.OtherWeaponProficiency); } }

        #endregion strikes

        #region skills

        public SkillViewModel Acrobatics { get { return new SkillViewModel(playerCharacter.Acrobatics); } }
        public SkillViewModel Arcana { get { return new SkillViewModel(playerCharacter.Arcana); } }
        public SkillViewModel Athletics { get { return new SkillViewModel(playerCharacter.Athletics); } }
        public SkillViewModel Crafting { get { return new SkillViewModel(playerCharacter.Crafting); } }
        public SkillViewModel Deception { get { return new SkillViewModel(playerCharacter.Deception); } }
        public SkillViewModel Diplomacy { get { return new SkillViewModel(playerCharacter.Diplomacy); } }
        public SkillViewModel Intimidation { get { return new SkillViewModel(playerCharacter.Intimidation); } }
        public SkillViewModel Lore1 { get { return new SkillViewModel(playerCharacter.Lore.First<Skill>()); } }
        public SkillViewModel Lore2 { get { return new SkillViewModel(playerCharacter.Lore.Last<Skill>()); } }
        public SkillViewModel Medicine { get { return new SkillViewModel(playerCharacter.Medicine); } }
        public SkillViewModel Nature { get { return new SkillViewModel(playerCharacter.Nature); } }
        public SkillViewModel Occultism { get { return new SkillViewModel(playerCharacter.Occultism); } }
        public SkillViewModel Performance { get { return new SkillViewModel(playerCharacter.Performance); } }
        public SkillViewModel Religion { get { return new SkillViewModel(playerCharacter.Religion); } }
        public SkillViewModel Society { get { return new SkillViewModel(playerCharacter.Society); } }
        public SkillViewModel Stealth { get { return new SkillViewModel(playerCharacter.Stealth); } }
        public SkillViewModel Survival { get { return new SkillViewModel(playerCharacter.Survival); } }
        public SkillViewModel Thievery { get { return new SkillViewModel(playerCharacter.Thievery); } }

        #endregion skills

        #region Languages

        public ObservableCollection<String> Languages {
            get {
                return new ObservableCollection<string>(playerCharacter.Languages);
            }
            set {
                playerCharacter.Languages = value;
                OnPropertyChanged();
            }
        }

        #endregion Languages

        #endregion Page1

        #region Page2

        public ObservableCollection<String> AncestryFeatsAndAbilities {
            get { return new ObservableCollection<String>(playerCharacter.AncestryFeatsAndAbilities); }
        }

        public ObservableCollection<String> SkillFeats {
            get { return new ObservableCollection<String>(playerCharacter.SkillFeats); }
        }

        public ObservableCollection<String> GeneralFeats {
            get { return new ObservableCollection<String>(playerCharacter.GeneralFeats); }
        }

        public ObservableCollection<IClassFeat> ClassFeatsAndAbilities {
            get { return new ObservableCollection<IClassFeat>(playerCharacter.ClassFeatsAndAbilities); }
        }

        public ObservableCollection<String> BonusFeats {
            get { return new ObservableCollection<String>(playerCharacter.BonusFeats); }
        }

        public ObservableCollection<String> WornItems { get { return new ObservableCollection<string>(playerCharacter.WornItems); } }
        public ObservableCollection<String> ReadiedItems { get { return new ObservableCollection<string>(playerCharacter.ReadiedItems); } }
        public ObservableCollection<String> OtherItems { get { return new ObservableCollection<string>(playerCharacter.OtherItems); } }
        public int TotalBulk { get { return playerCharacter.GetTotalBulk(); } }
        public int EncumberedBulk { get { return playerCharacter.GetEncumbered(); } }
        public int MaxBulk { get { return playerCharacter.GetMaxBulk(); } }
        public int Copper { get { return playerCharacter.Coins.Copper; } }
        public int Silver { get { return playerCharacter.Coins.Silver; } }
        public int Gold { get { return playerCharacter.Coins.Gold; } }
        public int Platinum { get { return playerCharacter.Coins.Platinum; } }

        #endregion Page2

        #region Page3

        // lots of metadata with no mechanical benefit
        // also some actions and such but these will be elsewhere

        #endregion Page3

        #region Page4

        public int SpellAttackRoll { get { return playerCharacter.GetSpellAttackRoll(); } }
        public int SpellKeyAbilityModifier { get { return playerCharacter.GetSpellKeyAbilityModifier(); } }
        public ProficiencyViewModel SpellAttackProficiency { get { return new ProficiencyViewModel(playerCharacter.GetSpellAttackProficiency()); } }
        public int SpellDC { get { return playerCharacter.GetSpellDC(); } }
        public int SpellDCModifier { get { return playerCharacter.GetSpellDCModifier(); } }
        public ProficiencyViewModel SpellDCProficiency { get { return new ProficiencyViewModel(playerCharacter.GetSpellDCProficiency()); } }
        public int CantripLevel { get { return playerCharacter.GetCantripLevel(); } }
        public int[] SpellSlotsPerDay { get { return playerCharacter.GetDailySpellSlot(); } }
        public ObservableCollection<string> Cantrips { get { return new ObservableCollection<string>(playerCharacter.GetCantrip()); } }
        public ObservableCollection<string> InnateSpells { get { return new ObservableCollection<string>(playerCharacter.GetInnateSpells()); } }
        public ObservableCollection<string> Spells { get { return new ObservableCollection<string>(playerCharacter.GetSpells()); } }
        public ObservableCollection<string> FocusSpells { get { return new ObservableCollection<string>(playerCharacter.GetFocusSpells()); } }

        #endregion Page4

        public PlayerCharacterSheetViewModel()
        {
            Title = "New Adventurer";
            playerCharacter = new PlayerCharacter(Ancestries.Dwarf, CharacterBackgrounds.Emancipated, PcClasses.Rogue);
            IsEditing = true;
        }

        public PlayerCharacterSheetViewModel(PlayerCharacter PC)
        {
            Title = "Character Sheet";
            playerCharacter = PC ?? new PlayerCharacter(Ancestries.Dwarf, new Emancipated(), new Rogue());
            IsEditing = true;
        }

        private string CheckNullString(string value)
        {
            return string.IsNullOrEmpty(value) ? "" : value;
        }
    }
}