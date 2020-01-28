using PF2E.Rules;

namespace PF2E_RulesLawyer.ViewModels
{
    public class ProficiencyViewModel
    {
        public ProficiencyViewModel(Proficiency aC_ProficiencyLevel)
        {
            if (aC_ProficiencyLevel > 0)
            {
                IsUntrained = false;
            }
            else if (aC_ProficiencyLevel >= Proficiency.Trained)
            {
            }
        }

        public bool IsUntrained { get; set; }
        public bool IsTrained { get; set; }
        public bool IsExpert { get; set; }
        public bool IsMaster { get; set; }
        public bool IsLegendary { get; set; }
    }
}