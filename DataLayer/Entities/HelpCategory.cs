using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

[Table("HelpCategory")]
public partial class HelpCategory
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? IdMse { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("HelpCategoryCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [InverseProperty("HelpCategory")]
    public virtual ICollection<IpraHelpCategory> IpraHelpCategories { get; set; } = new List<IpraHelpCategory>();

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("HelpCategoryModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;
}
