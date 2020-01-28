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
                if (aC_ProficiencyLevel >= Proficiency.Trained)
                {
                    IsTrained = true;
                    if (aC_ProficiencyLevel >= Proficiency.Expert)
                    {
                        IsExpert = true;
                        if (aC_ProficiencyLevel >= Proficiency.Master)
                        {
                            IsMaster = true;
                            if (aC_ProficiencyLevel >= Proficiency.Legendary)
                            {
                                IsLegendary = true;
                            }
                        }
                    }
                }
            }
            else
            {
                IsUntrained = true;
                IsTrained = false;
                IsExpert = false;
                IsMaster = false;
                IsLegendary = false;
            }
        }

        public bool IsUntrained { get; }
        public bool IsTrained { get; }
        public bool IsExpert { get; }
        public bool IsMaster { get; }
        public bool IsLegendary { get; }
    }
}