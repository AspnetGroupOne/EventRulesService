namespace Core.Domain.Models;

public class AddRulesRequest
{
    public string EventId { get; set; } = null!;
    public List<string> RuleItems { get; set; } = null!;
}
