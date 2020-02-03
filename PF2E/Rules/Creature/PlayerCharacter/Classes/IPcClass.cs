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
    }
}