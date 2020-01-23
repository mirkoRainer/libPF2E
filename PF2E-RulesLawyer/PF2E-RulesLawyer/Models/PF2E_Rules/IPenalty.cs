namespace PF2E_RulesLawyer.Models.Rules
{
    public interface IPenalty
    {
        string Type { get; set; }
        int Amount { get; set; }
    }
}