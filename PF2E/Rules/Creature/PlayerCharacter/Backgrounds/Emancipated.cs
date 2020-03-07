using System.Collections.Generic;

namespace PF2E.Rules.Creature.PlayerCharacter
{
    public class Emancipated : IBackground
    {
        public string Name => this.GetType().Name;

        public List<AbilityScoreBoostFlaw> AbilityBoostOptions {
            get => new List<AbilityScoreBoostFlaw>
                                                                                {
                                                                                    new AbilityScoreBoostFlaw(true, Ability.Dexterity),
                                                                                    new AbilityScoreBoostFlaw(true, Ability.Charisma)
                                                                                };
        }

        public AbilityScoreBoostFlaw AbilityScoreBoost => new AbilityScoreBoostFlaw(true, Ability.Free);

        public string SkillFeat { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string TrainedSkill { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string TrainedLoreSkill { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}