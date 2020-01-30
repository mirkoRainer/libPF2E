using PF2E.Rules.Creature;

namespace PF2E_RulesLawyer.ViewModels
{
    public class SkillViewModel
    {
        public ProficiencyViewModel Proficiency { get; set; }
        public int Modifier { get; set; }
        public string Descriptor { get; set; }

        public SkillViewModel(Skill skill)
        {
            Proficiency = new ProficiencyViewModel(skill.Proficiency);
            Modifier = skill.KeyAbilityModifier;
            Descriptor = string.IsNullOrWhiteSpace(skill.Descriptor) ? "" : skill.Descriptor;
        }
    }
}