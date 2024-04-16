using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

[Table("IpraStatus")]
public partial class IpraStatus
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("IpraStatusCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<Ipra> Ipras { get; set; } = new List<Ipra>();

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("IpraStatusModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;
}
