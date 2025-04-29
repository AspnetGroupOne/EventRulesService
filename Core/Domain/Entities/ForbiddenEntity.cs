
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities;

public class ForbiddenEntity
{
    [Key]
    public string EventId { get; set; } = null!;
    public string ItemName { get; set; } = null!;
}
