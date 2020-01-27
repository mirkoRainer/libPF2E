namespace PF2E.Rules
{
    public interface IPenalty
    {
        string Type { get; set; }
        int Amount { get; set; }
    }
}