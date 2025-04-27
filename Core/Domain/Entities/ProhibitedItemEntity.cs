using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

public class ProhibitedItemEntity
{
    [ForeignKey("EventRules")]
    public int EventRulesId { get; set; }

    [Required]
    public string ItemName { get; set; } = null!;

    public EventRulesEntity EventRules { get; set; } = null!;
}