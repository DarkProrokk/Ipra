using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

[Table("Result")]
public partial class Result
{
    [Key]
    public int Id { get; set; }

    [StringLength(1024)]
    public string? Name { get; set; }

    [StringLength(64)]
    public string? ShortName { get; set; }

    [StringLength(1024)]
    public string? MseName { get; set; }

    [InverseProperty("Result")]
    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
