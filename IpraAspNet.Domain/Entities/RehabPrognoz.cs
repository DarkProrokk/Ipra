using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IpraAspNet.Domain.Entities;

[Table("RehabPrognoz")]
public class RehabPrognoz
{
    [Key] public int Id { get; set; }

    public int? IdMse { get; set; }

    public string? Value { get; set; }
}