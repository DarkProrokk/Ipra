using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

[Table("RehabPrognoz")]
public partial class RehabPrognoz
{
    [Key]
    public int Id { get; set; }

    public int? IdMse { get; set; }

    public string? Value { get; set; }
}
