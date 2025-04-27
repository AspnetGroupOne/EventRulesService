namespace Core.Domain.Models;

public class EventRules
{
    public Guid EventId { get; set; }
    public List<ProhibitedItem> ProhibitedItems { get; set; } = new();
}
