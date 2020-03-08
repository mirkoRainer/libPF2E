using PF2E.Rules.Creature;
using PF2E.Rules.Creature.PlayerCharacter;
using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public class Rogue : IPcClass
    {
        public string Name { get { return "Rogue"; } }
        public int HitPoints { get { return 8; } }
        public string SubClass { get; private set; }
        public AbilityScoreBoostFlaw KeyAbilityScore { get { return new AbilityScoreBoostFlaw(true, Ability.Dexterity); } }
        public AbilityScoreBoostFlaw AlternateKeyAbilityScore {  get { return new AbilityScoreBoostFlaw(true, Ability.Strength); } }

        public string TypicalMembers => throw new System.NotImplementedException();

        public string RolePlayingSuggestions => throw new System.NotImplementedException();

        public Dictionary<string, Proficiency> Proficiencies => throw new System.NotImplementedException();

        public Dictionary<int, string[]> AdvancementTable => throw new System.NotImplementedException();

        public List<string> SubClasses => new List<string>
        {
            "Ruffian",
            "Scoundrel",
            "Thief"
        };

        public string NameOfSubClass => "Racket";

        List<IClassFeat> IPcClass.ClassFeats => throw new System.NotImplementedException();

        public int GetKeyAbilityScore()
        {
            throw new System.NotImplementedException();
        }

        public int GetKeyAbilityScoreModifier()
        {
            throw new System.NotImplementedException();
        }

        public Proficiency GetProficiency(PlayerCharacter.Proficiencies proficiencyWanted, int level)
        {
            throw new System.NotImplementedException();
        }

        public void SetSubClass(string value)
        {
            SubClass = value;
        }
    }
}