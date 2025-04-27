using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities;

public class EventRulesEntity
{
    [Key]
    public int Id { get; set; }

    //Need to check if the eventId is a guid.
    public Guid EventId { get; set; }
    public List<ProhibitedItemEntity> ProhibitedItems { get; set; } = new();
}
