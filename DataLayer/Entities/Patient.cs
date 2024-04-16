using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

public partial class Patient
{
    [Key]
    public int id { get; set; }

    [StringLength(50)]
    public string Surname { get; set; } = null!;

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string? Lastname { get; set; }

    public DateOnly? Birthday { get; set; }

    [StringLength(14)]
    public string? Snils { get; set; }

    [StringLength(16)]
    public string? ENP { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    public DateOnly? DeathDate { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("PatientCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [InverseProperty("Patient")]
    public virtual ICollection<Files> Files { get; set; } = new List<Files>();

    [InverseProperty("Patient")]
    public virtual ICollection<Ipra> Ipras { get; set; } = new List<Ipra>();

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("PatientModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;
}
