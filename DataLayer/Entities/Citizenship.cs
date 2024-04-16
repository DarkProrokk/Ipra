using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

[Table("Citizenship")]
public partial class Citizenship
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public int IdMse { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("CitizenshipCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [InverseProperty("Citizenship")]
    public virtual ICollection<Ipra> Ipras { get; set; } = new List<Ipra>();

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("CitizenshipModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;
}
