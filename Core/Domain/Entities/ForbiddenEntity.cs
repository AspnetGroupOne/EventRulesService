
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

[Table("Rules")]
public class ForbiddenEntity
{
    [Key]
    public string EventId { get; set; } = null!;
    public string ItemName { get; set; } = null!;
}
