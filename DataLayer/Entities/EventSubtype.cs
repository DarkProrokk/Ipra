using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

[Table("EventSubtype")]
public class EventSubtype
{
    [Key] public int Id { get; set; }

    public int TypeId { get; set; }

    [StringLength(1024)] public string? Name { get; set; }

    [StringLength(64)] public string? ShortName { get; set; }

    [InverseProperty("EventSubtype")] public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    [ForeignKey("TypeId")]
    [InverseProperty("EventSubtypes")]
    public virtual EventType Type { get; set; } = null!;
}