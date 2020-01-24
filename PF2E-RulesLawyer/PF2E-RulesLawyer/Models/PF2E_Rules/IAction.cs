using PF2E_RulesLawyer.Models.Rules.Encounters;

namespace PF2E_RulesLawyer.Models.Rules
{
    internal interface IAction
    {
        ActionCost ActionCost { get; set; }
        IAction[] SubordinateActions { get; set; }
        Trait[] Traits { get; set; }
        string Trigger { get; set; }
        ICheck Check { get; set; }
        IEffect Effect { get; set; }
    }
}