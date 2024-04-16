using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

[Table("RehabPotential")]
public class RehabPotential
{
    [Key] public int Id { get; set; }

    public int? IdMse { get; set; }

    public string? Value { get; set; }
}