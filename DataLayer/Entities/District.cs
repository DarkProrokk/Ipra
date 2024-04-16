using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

[Keyless]
[Table("District")]
public class District
{
    public int? Id { get; set; }

    [StringLength(50)] public string? Name { get; set; }
}