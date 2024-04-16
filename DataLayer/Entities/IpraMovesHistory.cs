using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

[Table("IpraMovesHistory")]
public partial class IpraMovesHistory
{
    [Key]
    public int Id { get; set; }

    public int IpraId { get; set; }

    public int MoveId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("IpraMovesHistories")]
    public virtual User CreatedUser { get; set; } = null!;

    [ForeignKey("IpraId")]
    [InverseProperty("IpraMovesHistories")]
    public virtual Ipra Ipra { get; set; } = null!;

    [ForeignKey("MoveId")]
    [InverseProperty("IpraMovesHistories")]
    public virtual Move Move { get; set; } = null!;
}
