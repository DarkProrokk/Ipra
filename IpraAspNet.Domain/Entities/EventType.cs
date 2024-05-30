using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IpraAspNet.Domain.Entities;

[Table("EventType")]
public class EventType
{
    [Key] public int Id { get; set; }

    [StringLength(1024)] public string? Name { get; set; }

    [StringLength(64)] public string? ShortName { get; set; }

    [InverseProperty("Type")]
    public virtual ICollection<EventSubtype> EventSubtypes { get; set; } = new List<EventSubtype>();

    [InverseProperty("EventType")] public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}