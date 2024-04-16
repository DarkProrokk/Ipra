using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

public partial class Report
{
    [Key]
    public int Id { get; set; }

    public int IpraId { get; set; }

    public int EventTypeId { get; set; }

    public int? EventSubtypeId { get; set; }

    [StringLength(128)]
    public string? CustomEvent { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DatePerfomance { get; set; }

    public int? ExecutorId { get; set; }

    [StringLength(128)]
    public string? CustomExecutor { get; set; }

    public int? ResultId { get; set; }

    [StringLength(128)]
    public string? CustomResult { get; set; }

    [StringLength(64)]
    public string? Note { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedTS { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("Reports")]
    public virtual User CreatedUser { get; set; } = null!;

    [ForeignKey("EventSubtypeId")]
    [InverseProperty("Reports")]
    public virtual EventSubtype? EventSubtype { get; set; }

    [ForeignKey("EventTypeId")]
    [InverseProperty("Reports")]
    public virtual EventType EventType { get; set; } = null!;

    [ForeignKey("ExecutorId")]
    [InverseProperty("Reports")]
    public virtual Executor? Executor { get; set; }

    [ForeignKey("IpraId")]
    [InverseProperty("Reports")]
    public virtual Ipra Ipra { get; set; } = null!;

    [ForeignKey("ResultId")]
    [InverseProperty("Reports")]
    public virtual Result? Result { get; set; }
}
