using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

public class Executor
{
    [Key] public int Id { get; set; }

    [StringLength(100)] public string Shortname { get; set; } = null!;

    public string? Fullname { get; set; }

    [InverseProperty("Executor")] public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}