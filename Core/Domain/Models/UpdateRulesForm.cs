namespace Core.Domain.Models;

public class UpdateRulesForm
{
    public string EventId { get; set; } = null!;
    public List<string> RuleItems { get; set; } = null!;
}
