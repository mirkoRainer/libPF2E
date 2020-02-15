using System;
using System.Collections.ObjectModel;
using System.Text;
using PF2E.Rules;
using PF2E.Rules.Creature;
using PF2E.Rules.Creature.PlayerCharacter;
using System.Linq;
using PF2E_RulesLawyer.Services;

namespace PF2E_RulesLawyer.ViewModels
{
    public class PlayerCharacterSheetViewModel : BaseViewModel
    {
        public PlayerCharacter PlayerCharacter { get; set; }

        #region Page1

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
            get { return PlayerCharacter.PcClass.Name; }
        }

        public String SubClass {
            get { return PlayerCharacter.SubClass; }
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

        public String Alignment {
            get { return PlayerCharacter.Alignment.ToString(); }
            set {
                PlayerCharacter.SetNewAlignment(value);
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
            get { return PlayerCharacter.AbilityScores.Strength.Score; }
            set {
                PlayerCharacter.AbilityScores.Strength = new AbilityScore(value, Ability.Strength); ;
                OnPropertyChanged();
            }
        }

        public int StrengthModifier {
            get { return PlayerCharacter.AbilityScores.Strength.Modifier; }
        }

        public int Dexterity {
            get { return PlayerCharacter.AbilityScores.Dexterity.Score; }
            set {
                PlayerCharacter.AbilityScores.Dexterity = new AbilityScore(value, Ability.Dexterity);
                OnPropertyChanged();
            }
        }

        public int DexterityModifier {
            get { return PlayerCharacter.AbilityScores.Dexterity.Modifier; }
        }

        public int Constitution {
            get { return PlayerCharacter.AbilityScores.Constitution.Score; }
            set {
                PlayerCharacter.AbilityScores.Constitution = new AbilityScore(value, Ability.Constitution);
                OnPropertyChanged();
            }
        }

        public int ConstitutionModifier {
            get { return PlayerCharacter.AbilityScores.Constitution.Modifier; }
        }

        public int Intelligence {
            get { return PlayerCharacter.AbilityScores.Intelligence.Score; }
            set {
                PlayerCharacter.AbilityScores.Intelligence = new AbilityScore(value, Ability.Intelligence);
                OnPropertyChanged();
            }
        }

        public int IntelligenceModifier {
            get { return PlayerCharacter.AbilityScores.Intelligence.Modifier; }
        }

        public int Wisdom {
            get { return PlayerCharacter.AbilityScores.Wisdom.Score; }
            set {
                PlayerCharacter.AbilityScores.Wisdom = new AbilityScore(value, Ability.Wisdom);
                OnPropertyChanged();
            }
        }

        public int WisdomModifier {
            get { return PlayerCharacter.AbilityScores.Wisdom.Modifier; }
        }

        public int Charisma {
            get { return PlayerCharacter.AbilityScores.Charisma.Score; }
            set {
                PlayerCharacter.AbilityScores.Charisma = new AbilityScore(value, Ability.Charisma);
                OnPropertyChanged();
            }
        }

        public int CharismaModifier {
            get { return PlayerCharacter.AbilityScores.Charisma.Modifier; }
        }

        #endregion AbilityScores

        #region ArmorClass

        public int ArmorClass => PlayerCharacter.ArmorClass.Amount;
        public int ACDexCap { get { return PlayerCharacter.Armor.DexCap; } }

        public ProficiencyViewModel AC_ProficiencyLevel {
            get {
                return ConvertProficiencyToViewModel(PlayerCharacter.ArmorClass.Proficiency);
            }
        }

        private ProficiencyViewModel ConvertProficiencyToViewModel(Proficiency aC_ProficiencyLevel)
        {
            return new ProficiencyViewModel(aC_ProficiencyLevel);
        }

        public int AC_ItemBonus { get { return PlayerCharacter.Armor.ACBonus; } }

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
            get { return ConvertProficiencyToViewModel(PlayerCharacter.FortitudeSave.Proficiency); }
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
            get { return ConvertProficiencyToViewModel(PlayerCharacter.ReflexSave.Proficiency); }
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
            get { return ConvertProficiencyToViewModel(PlayerCharacter.WillSave.Proficiency); }
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

        public int Perception { get { return PlayerCharacter.Perception.Amount; } }
        public int PerceptionProficiencyBonus { get { return PlayerCharacter.Perception.ProficiencyBonus; } }
        public ProficiencyViewModel PerceptionProficiency { get { return ConvertProficiencyToViewModel(PlayerCharacter.Perception.Proficiency); } }
        public int PerceptionItemBonus { get { return PlayerCharacter.Perception.ItemBonus; } }
        public ObservableCollection<String> Senses { get { return new ObservableCollection<string>(PlayerCharacter.Senses); } }

        #endregion Perception

        #region ClassDC

        public int ClassDC { get { return PlayerCharacter.ClassDC.Amount; } }

        public int ClassDCKeyAbilityModifier {
            get { return PlayerCharacter.PcClass.GetKeyAbilityScoreModifier(); }
        }

        public int ClassDCProficiencyBonus {
            get { return PlayerCharacter.ClassDC.ProficiencyBonus; }
        }

        public ProficiencyViewModel ClassProficiency { get { return ConvertProficiencyToViewModel(PlayerCharacter.ClassDC.Proficiency); } }

        public int ClassDCItemBonus {
            get { return PlayerCharacter.ClassDC.ItemBonus; }
        }

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

        #region skills

        public SkillViewModel Acrobatics { get { return new SkillViewModel(PlayerCharacter.Acrobatics); } }
        public SkillViewModel Arcana { get { return new SkillViewModel(PlayerCharacter.Arcana); } }
        public SkillViewModel Athletics { get { return new SkillViewModel(PlayerCharacter.Athletics); } }
        public SkillViewModel Crafting { get { return new SkillViewModel(PlayerCharacter.Crafting); } }
        public SkillViewModel Deception { get { return new SkillViewModel(PlayerCharacter.Deception); } }
        public SkillViewModel Diplomacy { get { return new SkillViewModel(PlayerCharacter.Diplomacy); } }
        public SkillViewModel Intimidation { get { return new SkillViewModel(PlayerCharacter.Intimidation); } }
        public SkillViewModel Lore1 { get { return new SkillViewModel(PlayerCharacter.Lore.First<Skill>()); } }
        public SkillViewModel Lore2 { get { return new SkillViewModel(PlayerCharacter.Lore.Last<Skill>()); } }
        public SkillViewModel Medicine { get { return new SkillViewModel(PlayerCharacter.Medicine); } }
        public SkillViewModel Nature { get { return new SkillViewModel(PlayerCharacter.Nature); } }
        public SkillViewModel Occultism { get { return new SkillViewModel(PlayerCharacter.Occultism); } }
        public SkillViewModel Performance { get { return new SkillViewModel(PlayerCharacter.Performance); } }
        public SkillViewModel Religion { get { return new SkillViewModel(PlayerCharacter.Religion); } }
        public SkillViewModel Society { get { return new SkillViewModel(PlayerCharacter.Society); } }
        public SkillViewModel Stealth { get { return new SkillViewModel(PlayerCharacter.Stealth); } }
        public SkillViewModel Survival { get { return new SkillViewModel(PlayerCharacter.Survival); } }
        public SkillViewModel Thievery { get { return new SkillViewModel(PlayerCharacter.Thievery); } }

        #endregion skills

        #region Languages

        public ObservableCollection<String> Languages {
            get {
                return new ObservableCollection<string>(PlayerCharacter.Languages);
            }
            set {
                PlayerCharacter.Languages = value;
                OnPropertyChanged();
            }
        }

        #endregion Languages

        #endregion Page1

        #region Page2

        public ObservableCollection<String> AncestryFeatsAndAbilities {
            get { return new ObservableCollection<String>(PlayerCharacter.AncestryFeatsAndAbilities); }
        }

        public ObservableCollection<String> SkillFeats {
            get { return new ObservableCollection<String>(PlayerCharacter.SkillFeats); }
        }

        public ObservableCollection<String> GeneralFeats {
            get { return new ObservableCollection<String>(PlayerCharacter.GeneralFeats); }
        }

        public ObservableCollection<IClassFeat> ClassFeatsAndAbilities {
            get { return new ObservableCollection<IClassFeat>(PlayerCharacter.ClassFeatsAndAbilities); }
        }

        public ObservableCollection<String> BonusFeats {
            get { return new ObservableCollection<String>(PlayerCharacter.BonusFeats); }
        }

        public ObservableCollection<String> WornItems { get { return new ObservableCollection<string>(PlayerCharacter.WornItems); } }
        public ObservableCollection<String> ReadiedItems { get { return new ObservableCollection<string>(PlayerCharacter.ReadiedItems); } }
        public ObservableCollection<String> OtherItems { get { return new ObservableCollection<string>(PlayerCharacter.OtherItems); } }
        public int TotalBulk { get { return PlayerCharacter.GetTotalBulk(); } }
        public int EncumberedBulk { get { return PlayerCharacter.GetEncumbered(); } }
        public int MaxBulk { get { return PlayerCharacter.GetMaxBulk(); } }
        public int Copper { get { return PlayerCharacter.Coins.Copper; } }
        public int Silver { get { return PlayerCharacter.Coins.Silver; } }
        public int Gold { get { return PlayerCharacter.Coins.Gold; } }
        public int Platinum { get { return PlayerCharacter.Coins.Platinum; } }

        #endregion Page2

        #region Page3

        // lots of metadata with no mechanical benefit
        // also some actions and such but these will be elsewhere

        #endregion Page3

        #region Page4

        public int SpellAttackRoll { get { return PlayerCharacter.GetSpellAttackRoll(); } }
        public int SpellKeyAbilityModifier { get { return PlayerCharacter.GetSpellKeyAbilityModifier(); } }
        public ProficiencyViewModel SpellAttackProficiency { get { return new ProficiencyViewModel(PlayerCharacter.GetSpellAttackProficiency()); } }
        public int SpellDC { get { return PlayerCharacter.GetSpellDC(); } }
        public int SpellDCModifier { get { return PlayerCharacter.GetSpellDCModifier(); } }
        public ProficiencyViewModel SpellDCProficiency { get { return new ProficiencyViewModel(PlayerCharacter.GetSpellDCProficiency()); } }
        public int CantripLevel { get { return PlayerCharacter.GetCantripLevel(); } }
        public int[] SpellSlotsPerDay { get { return PlayerCharacter.GetDailySpellSlot(); } }
        public ObservableCollection<string> Cantrips { get { return new ObservableCollection<string>(PlayerCharacter.GetCantrip()); } }
        public ObservableCollection<string> InnateSpells { get { return new ObservableCollection<string>(PlayerCharacter.GetInnateSpells()); } }
        public ObservableCollection<string> Spells { get { return new ObservableCollection<string>(PlayerCharacter.GetSpells()); } }
        public ObservableCollection<string> FocusSpells { get { return new ObservableCollection<string>(PlayerCharacter.GetFocusSpells()); } }

        #endregion Page4

        public PlayerCharacterSheetViewModel()
        {
            Title = "New Adventurer";
            CharacterName = "New Adventurer";
            PlayerCharacter = new PlayerCharacter(Ancestries.Dwarf, new EmancipatedBackground(), new Rogue(), CharacterName);
        }

        public PlayerCharacterSheetViewModel(PlayerCharacter PC)
        {
            Title = "Character Sheet";
            PlayerCharacter = PC ?? new PlayerCharacter(Ancestries.Dwarf, new EmancipatedBackground(), new Rogue(), "Salazat");
        }
    }
}