using PF2E_RulesLawyer.Models.PF2e_Rules.Creature.PlayerCharacter.Ancestries;
using PF2E.Rules;
using PF2E.Rules.Creature;
using PF2E.Rules.Creature.PlayerCharacter;
using System;
using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public class PlayerCharacter
    {
        public string Id { get; set; }
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

        public AbilityScore Strength { get; set; }
        public AbilityScore Dexterity { get; set; }
        public AbilityScore Constitution { get; set; }
        public AbilityScore Intelligence { get; set; }
        public AbilityScore Wisdom { get; set; }
        public AbilityScore Charisma { get; set; }

        // Armor Class

        public int ArmorClass { get { return CalculateArmorClass(); } }

        private int CalculateArmorClass()
        {
            throw new NotImplementedException();
        }

        public int AC_CapDexBonus { get { return DetermineArmorDexterityCap(); } }

        private int DetermineArmorDexterityCap()
        {
            throw new NotImplementedException();
        }

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

        public Save FortitudeSave { get; set; }
        public Save ReflexSave { get; set; }
        public Save WillSave { get; set; }
        public Proficiency FortitudeProficiency { get; set; }
        public Proficiency ReflexProficiency { get; set; }
        public Proficiency WillProficiency { get; set; }

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

        public int Perception { get; set; }
        public int PerceptionProficiencyBonus { get; set; }
        public Proficiency PerceptionProficiency { get; set; }
        public int PerceptionItemBonus { get; set; }
        public IEnumerable<String> Senses { get; set; }

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

        public Skill Acrobatics { get; set; }
        public Skill Arcana { get; set; }
        public Skill Athletics { get; set; }
        public Skill Crafting { get; set; }
        public Skill Deception { get; set; }
        public Skill Diplomacy { get; set; }
        public Skill Intimidation { get; set; }
        public Skill Lore1 { get; set; }
        public Skill Lore2 { get; set; }
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

        public PlayerCharacter(string name)
        {
            Name = name;
        }
    }
}