using PF2E.Rules.Equipment;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public class PlayerCharacter
    {
        public Guid Id { get; set; }

        #region characterSheetPage1

        public string Name { get; set; }
        public IAncestry Ancestry { get; set; }
        public IBackground Background { get; set; }
        public IHeritage Heritage { get; set; }
        public int Level { get; set; }
        public string PlayerName { get; set; }
        public IPcClass PcClass { get; set; }
        public Size Size { get; set; }
        public Alignment Alignment { get; set; }
        public IEnumerable<Trait> Traits { get; set; }
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
            string name = "Default Name",
            string playerName = "Player"
            )
        {
            Name = name;
            Id = new Guid();
            Ancestry = ancestry;
            Background = background;
            PcClass = pcclass;
            Level = 1;
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