using PF2E.Rules.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public class PlayerCharacter
    {
        public Guid Id { get; set; }

        #region characterSheetPage1

        public string Name { get; set; }
        public IAncestry Ancestry { get; private set; }

        public void SetAncestry(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                value = PF2eCoreUtils.GetListOfAncestries().First();
            }
            try
            {
                var ancestriesType = typeof(Ancestries);
                var ancestry = (IAncestry)ancestriesType.GetField(value).GetValue(null);
                Ancestry = ancestry;
            }
            catch (Exception e)
            {
                throw new Exception($"Check the Ancestries.cs file to see if {value} has a property there. Could not assign {value} as an Ancestry. Invalid Ancestry name or String.  {e.Message}");
            }
        }

        public IBackground Background { get; set; }

        public void SetBackground(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                value = PF2eCoreUtils.GetListOfBackgrounds().First();
            }
            try
            {
                var backgroundTypes = typeof(CharacterBackgrounds);
                var background = (IBackground)backgroundTypes.GetField(value).GetValue(null);
                Background = background;
                BackgroundAbilityChoice = background.AbilityBoostOptions.First();
            }
            catch (Exception e)
            {
                throw new Exception($"Check to make sure {value} exists in the CharacterBackgrounds.cs file. Could not assign {value} as an Background. Invalid Background name or String. {e.Message}");
            }
        }

        public AbilityScoreBoostFlaw BackgroundAbilityChoice { get; private set; }

        public void SetBackgroundAbility(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                BackgroundAbilityChoice = new AbilityScoreBoostFlaw(true, Ability.Strength);
            }
            else
            {
                var ability = (Ability)Enum.Parse(typeof(Ability), value);
                BackgroundAbilityChoice = new AbilityScoreBoostFlaw(true, ability);
            }
        }

        public List<string> GetBackgroundAbilityChoices()
        {
            var choices = Background.AbilityBoostOptions;
            var choicesStrings = from choice in choices
                                 select choice.Ability;
            return choicesStrings.ToList();
        }

        public IHeritage Heritage { get; set; }
        public int Level { get; set; }

        public IPcClass PcClass { get; set; }

        public void SetClass(string value)
        {
            try
            {
                var classTypes = typeof(PcClasses);
                var pcClass = (IPcClass)classTypes.GetField(value).GetValue(null);
                PcClass = pcClass;
            }
            catch (Exception e)
            {
                throw new Exception($" Make sure {value} has an entry in the PcClasses.cs file. Could not assign {value} as an PcClass. Invalid PcClass name or String. {e.Message}");
            }
        }

        public string PlayerName {
            get;
            set;
        }

        public Size Size { get; set; }
        public Alignment Alignment { get; set; }

        public List<Trait> Traits {
            get; set;
        }

        public String Deity { get; set; }
        public int HeroPoints { get; set; }
        public int ExperiencePoints { get; set; }

        // Ability Scores
        public AbilityScoreArray AbilityScores { get; set; }

        // Armor Class

        public ArmorClass ArmorClass { get; set; }
        public Armor Armor { get; set; }

        public Proficiency UnarmoredProficiency { get; set; }
        public Proficiency LightArmorProficiency { get; set; }
        public Proficiency MediumArmorProficiency { get; set; }
        public Proficiency HeavyArmorProficiency { get; set; }

        public void SetNewAlignment(string value)
        {
            throw new NotImplementedException();
        }

        public int ShieldBonus { get; set; }
        public int ShieldHardness { get; set; }
        public int ShieldMaxHitPoints { get; set; }
        public int ShieldBrokenThreshold { get; set; }
        public int ShieldCurrentHitPoints { get; set; }

        // Saving throws

        public ProficiencyBasedNumber FortitudeSave { get; set; }
        public ProficiencyBasedNumber ReflexSave { get; set; }
        public ProficiencyBasedNumber WillSave { get; set; }

        // Hit Points

        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int TemporaryHitPoints { get; set; }
        public int DyingValue { get; set; }
        public int WoundedValue { get; set; }
        public IEnumerable<String> Resistances { get; set; }
        public IEnumerable<String> Immunities { get; set; }
        public IEnumerable<String> Conditions { get; set; }

        // Perception

        public ProficiencyBasedNumber Perception { get; set; }
        public IEnumerable<String> Senses { get; set; }

        // Class DC

        public ProficiencyBasedNumber ClassDC { get; set; }

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

        public int SkillPoints { get; set; } // for tracking number of skills allowed at a level
        public Skill Acrobatics { get; set; }
        public Skill Arcana { get; set; }
        public Skill Athletics { get; set; }
        public Skill Crafting { get; set; }
        public Skill Deception { get; set; }
        public Skill Diplomacy { get; set; }
        public Skill Intimidation { get; set; }
        public List<Skill> Lore { get; set; }
        public Skill Medicine { get; set; }
        public Skill Nature { get; set; }
        public Skill Occultism { get; set; }
        public Skill Performance { get; set; }
        public Skill Religion { get; set; }
        public Skill Society { get; set; }
        public Skill Stealth { get; set; }
        public Skill Survival { get; set; }
        public Skill Thievery { get; set; }

        // Languages

        public IEnumerable<String> Languages { get; set; }

        #endregion characterSheetPage1

        #region characterSheetPage2

        public List<string> AncestryFeatsAndAbilities { get; set; }
        public List<string> SkillFeats { get; set; }
        public List<string> GeneralFeats { get; set; }
        public List<IClassFeat> ClassFeatsAndAbilities { get; set; }
        public List<string> BonusFeats { get; set; }
        public List<string> WornItems { get; set; }
        public List<string> ReadiedItems { get; set; }
        public List<string> OtherItems { get; set; }
        public Coins Coins { get; set; }
        public string SubClass { get; set; }

        public int GetTotalBulk()
        {
            // for each item get bulk and add
            throw new NotImplementedException();
        }

        public int GetEncumbered()
        {
            return 5 + AbilityScores.Strength.Modifier;
        }

        public int GetMaxBulk()
        {
            return 10 + AbilityScores.Strength.Modifier;
        }

        #endregion characterSheetPage2

        public PlayerCharacter(
            IAncestry ancestry,
            IBackground background,
            IPcClass pcclass,
            string name = "",
            string playerName = "Player"
            )
        {
            Name = name;
            Id = new Guid();
            Ancestry = ancestry;
            Background = background;
            PcClass = pcclass;
            Level = 1;
            Traits = new List<Trait>();
            Traits.AddRange(ancestry.Traits);
            PlayerName = playerName;
            var boostsFlaws = new List<AbilityScoreBoostFlaw>();
            boostsFlaws.AddRange(ancestry.AbilityBoosts);
            boostsFlaws.AddRange(ancestry.AbilityFlaws);
            boostsFlaws.AddRange(background.AbilityBoostOptions);
            boostsFlaws.Add(pcclass.KeyAbilityScore);
            AbilityScores = new AbilityScoreArray(boostsFlaws);
            var backgroundAbilityChoices = background.AbilityBoostOptions;
            BackgroundAbilityChoice = backgroundAbilityChoices.First();
        }

        public enum Proficiencies
        {
            Unarmed,
            SimpleWeapon,
            MartialWeapon,
            OtherWeapon,
            Class,
            Perception,
            Will,
            Reflex,
            Fortitude,
            HeavyArmor,
            MediumArmor,
            LightArmor,
            Unarmored,
            Acrobatics,
            Arcana,
            Athletics,
            Crafting,
            Deception,
            Diplomacy,
            Intimidation,
            Lore,
            Medicine,
            Nature,
            Occultism,
            Performance,
            Religion,
            Society,
            Stealth,
            Survival,
            Thievery
        }

        public int GetSpellAttackRoll()
        {
            return 0;
        }

        public int GetSpellKeyAbilityModifier()
        {
            return 0;
        }

        public Proficiency GetSpellAttackProficiency()
        {
            return Proficiency.Untrained;
        }

        public int GetSpellDCModifier()
        {
            return 0;
        }

        public int GetSpellDC()
        {
            return 0;
        }

        public Proficiency GetSpellDCProficiency()
        {
            return Proficiency.Untrained;
        }

        public int GetCantripLevel()
        {
            return 0;
        }

        public int[] GetDailySpellSlot()
        {
            return new int[] { 0, 0 };
        }

        public List<string> GetCantrip()
        {
            throw new NotImplementedException();
        }

        public List<string> GetInnateSpells()
        {
            throw new NotImplementedException();
        }

        public List<string> GetSpells()
        {
            throw new NotImplementedException();
        }

        public List<string> GetFocusSpells()
        {
            throw new NotImplementedException();
        }
    }
}