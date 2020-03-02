using PF2E.Rules.Equipment;
using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public static class PlayerCharacterBuilder
    {
        public static PlayerCharacter PlayerCharacter { get; set; }

        public static PlayerCharacter NewPlayerCharacter(
            IAncestry ancestry,
            IBackground background,
            IPcClass pcClass,
            string name = "Default Name",
            string playerName = "Player"
            )
        {
            PlayerCharacter = new PlayerCharacter
            (
                ancestry,
                background,
                pcClass,
                name,
                playerName
            )
            {
                Size = ancestry.Size,
                Traits = new List<Trait>()
            };

            var boostsAndFlaws = new List<AbilityScoreBoostFlaw>();
            boostsAndFlaws.AddRange(PlayerCharacter.Ancestry.AbilityBoosts);
            boostsAndFlaws.AddRange(PlayerCharacter.Background.AbilityBoosts);
            boostsAndFlaws.Add(PlayerCharacter.PcClass.KeyAbilityScore);
            boostsAndFlaws.AddRange(PlayerCharacter.Ancestry.AbilityFlaws);

            PlayerCharacter.AbilityScores = new AbilityScoreArray(boostsAndFlaws);

            PlayerCharacter.Armor = new Armor();

            PlayerCharacter.UnarmoredProficiency = pcClass.GetProficiency(PlayerCharacter.Proficiencies.Unarmored, PlayerCharacter.Level);
            PlayerCharacter.LightArmorProficiency = pcClass.GetProficiency(PlayerCharacter.Proficiencies.LightArmor, PlayerCharacter.Level);
            PlayerCharacter.MediumArmorProficiency = pcClass.GetProficiency(PlayerCharacter.Proficiencies.MediumArmor, PlayerCharacter.Level);
            PlayerCharacter.HeavyArmorProficiency = pcClass.GetProficiency(PlayerCharacter.Proficiencies.HeavyArmor, PlayerCharacter.Level);

            PlayerCharacter.ArmorClass = new ArmorClass(

                PlayerCharacter.UnarmoredProficiency,
                PlayerCharacter.Level,
                PlayerCharacter.AbilityScores.Dexterity.Modifier,
                PlayerCharacter.Armor
            );

            PlayerCharacter.FortitudeSave = new ProficiencyBasedNumber(
                pcClass.GetProficiency(PlayerCharacter.Proficiencies.Fortitude, PlayerCharacter.Level),
                PlayerCharacter.Level,
                PlayerCharacter.AbilityScores.Constitution.Modifier

            );

            PlayerCharacter.ReflexSave = new ProficiencyBasedNumber(
                pcClass.GetProficiency(PlayerCharacter.Proficiencies.Reflex, PlayerCharacter.Level),
                PlayerCharacter.Level,
                PlayerCharacter.AbilityScores.Dexterity.Modifier

            );

            PlayerCharacter.WillSave = new ProficiencyBasedNumber(
                pcClass.GetProficiency(PlayerCharacter.Proficiencies.Will, PlayerCharacter.Level),
                PlayerCharacter.Level,
                PlayerCharacter.AbilityScores.Wisdom.Modifier

            );

            PlayerCharacter.MaxHitPoints = ancestry.HitPoints + pcClass.HitPoints + PlayerCharacter.AbilityScores.Constitution.Modifier;

            PlayerCharacter.Perception = new ProficiencyBasedNumber(
                PlayerCharacter.PcClass.GetProficiency(PlayerCharacter.Proficiencies.Perception, PlayerCharacter.Level),
                PlayerCharacter.Level,
                PlayerCharacter.AbilityScores.Wisdom.Modifier
            );

            PlayerCharacter.ClassDC = new ProficiencyBasedNumber(
                PlayerCharacter.PcClass.GetProficiency(PlayerCharacter.Proficiencies.OtherWeapon, PlayerCharacter.Level),
                PlayerCharacter.Level,
                pcClass.GetKeyAbilityScore(),
                    true
                );

            PlayerCharacter.Speed = ancestry.Speed;
            PlayerCharacter.UnarmedProficiency = pcClass.GetProficiency(PlayerCharacter.Proficiencies.Unarmed, PlayerCharacter.Level);
            PlayerCharacter.SimpleWeaponProficiency = pcClass.GetProficiency(PlayerCharacter.Proficiencies.SimpleWeapon, PlayerCharacter.Level);
            PlayerCharacter.MartialWeaponProficiency = pcClass.GetProficiency(PlayerCharacter.Proficiencies.MartialWeapon, PlayerCharacter.Level);
            PlayerCharacter.OtherWeaponProficiency = pcClass.GetProficiency(PlayerCharacter.Proficiencies.OtherWeapon, PlayerCharacter.Level);
            return PlayerCharacter;
        }
    }
}