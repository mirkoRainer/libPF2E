using PF2E_RulesLawyer.Models.PF2e_Rules.Creature.PlayerCharacter.Ancestries;
using PF2E_RulesLawyer.Models.Rules;
using PF2E_RulesLawyer.Models.Rules.Creature;
using PF2E_RulesLawyer.Models.Rules.Creature.PlayerCharacter;
using System;
using System.Collections.Generic;

namespace PF2E_RulesLawyer.Models
{
    public class PlayerCharacter
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IAncestry Ancestry { get; set; }
        public string Background { get; set; }
        public string PF2eClass { get; set; }
        public String Heritage { get; set; }
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
        public int WisdomModifier { get; set; }
        public int Charisma { get; set; }
        public int CharismaModifier { get; set; }

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

        public IEnumerable<String> Languages { get; set; }

        public PlayerCharacter(string name)
        {
            Name = name;
            PlayerName = "Mike Snow";
            PcClass = "Rogue";
            Ancestry = new Dwarf();
            Size = Ancestry.Size.ToString();
            Alignment = "CG";
            Traits = "Dwarven, Humanoid";
            Deity = "Tourag";
            HeroPoints = 1;
            ExperiencePoints = 10;
            Strength = 18;
            StrengthModifier = new AbilityModifier(
                new AbilityScore(Strength, Ability.Strength))
                    .Amount;
            Dexterity = 12;
            DexterityModifier = new AbilityModifier(
                new AbilityScore(Dexterity, Ability.Dexterity))
                    .Amount;
            Constitution = 16;
            ConstitutionModifier = new AbilityModifier(
                new AbilityScore(Constitution, Ability.Constitution))
                    .Amount;
            Intelligence = 10;
            IntelligenceModifier = new AbilityModifier(
                new AbilityScore(Intelligence, Ability.Intelligence))
                    .Amount;
            Wisdom = 18;
            WisdomModifier = new AbilityModifier(
                new AbilityScore(Wisdom, Ability.Wisdom))
                    .Amount;
            Charisma = 8;
            CharismaModifier = new AbilityModifier(
                new AbilityScore(Charisma, Ability.Charisma))
                    .Amount;
            ArmorClass = 18;
            AC_CapDexBonus = 1;
            AC_ProficiencyBonus = 4;
            AC_ProficiencyLevel = Proficiency.Expert;
            AC_ItemBonus = 3;
            UnarmoredProficiency = Proficiency.Trained;
            LightArmorProficiency = Proficiency.Trained;
            MediumArmorProficiency = Proficiency.Expert;
            HeavyArmorProficiency = Proficiency.Expert;
            ShieldBonus = 1;
            ShieldMaxHitPoints = 10;
            ShieldBrokenThreshold = 5;
            ShieldHardness = 3;
            ShieldCurrentHitPoints = 3;
        }
    }
}