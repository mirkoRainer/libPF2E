namespace PF2E.Rules.Creature.PlayerCharacter
{
    public interface IPcClass
    {
        string Name { get; }
        int HitPoints { get; }
        IPcFeat[] ClassFeats { get; set; }
        string SubClass { get; set; }
        AbilityScoreBoostFlaw KeyAbilityScore { get; }

        void SetSubClass(string value);

        Proficiency GetFortitudeProficiency(int level);

        Proficiency GetReflexProficiency(int level);

        Proficiency GetWillProficiency(int level);

        Proficiency GetUnarmoredProficiency(int level);

        Proficiency GetLightArmorProficiency(int level);

        Proficiency GetMediumArmorProficiency(int level);

        Proficiency GetHeavyArmorProficiency(int level);

        Proficiency GetPerceptionProficiency(int level);
    }
}