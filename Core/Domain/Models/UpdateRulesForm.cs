namespace Core.Domain.Models;

public class UpdateRulesForm
{
    public Guid Id { get; set; }
    public List<string> Rules { get; set; } = null!;
}
