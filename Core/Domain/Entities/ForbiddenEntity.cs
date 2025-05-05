
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

[Table("ForbiddenItems")]
public class ForbiddenEntity
{
    [Key]
    public string EventId { get; set; } = null!;
    public bool Alcohol { get; set; }
    public bool Bike { get; set; }
    public bool Camera { get; set; }
    public bool Hazard { get; set; }
    public bool Knife { get; set; }
    public bool Merch { get; set; }
    public bool Noise { get; set; }
    public bool Pets { get; set; }
    public bool Picnic { get; set; }
    public bool Pill { get; set; }
    public bool Tent { get; set; }
    public bool Umbrella { get; set; }
}
