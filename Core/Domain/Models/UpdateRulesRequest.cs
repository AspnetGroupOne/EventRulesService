namespace Core.Domain.Models;

public class UpdateRulesRequest
{
    public string EventId { get; set; } = null!;
    public List<string> RuleItems { get; set; } = null!;
}
