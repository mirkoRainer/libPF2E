using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public interface IPcClass
    {
        // pg67 CRB

        string Name { get; }
        string TypicalMembers { get; }
        string RolePlayingSuggestions { get; }
        AbilityScoreBoostFlaw KeyAbilityScore { get; }
        AbilityScoreBoostFlaw AlternateKeyAbilityScore { get; }
        int HitPoints { get; }
        Dictionary<string, Proficiency> Proficiencies { get; }
        Dictionary<int, string[]> AdvancementTable { get; }
        List<IClassFeat> ClassFeats { get; }
        string NameOfSubClass { get; }
        string SubClass { get; }
        List<string> SubClasses { get; }

        Proficiency GetProficiency(PlayerCharacter.Proficiencies proficiencyWanted, int level);

        int GetKeyAbilityScore();
        int GetKeyAbilityScoreModifier();
        void SetSubClass(string value);
    }
}