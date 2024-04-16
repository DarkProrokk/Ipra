using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

[Table("IpraHelpCategory")]
public class IpraHelpCategory
{
    public int IpraId { get; set; }

    public int HelpCategoryId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    [Key] public int Id { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("IpraHelpCategoryCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [ForeignKey("HelpCategoryId")]
    [InverseProperty("IpraHelpCategories")]
    public virtual HelpCategory HelpCategory { get; set; } = null!;

    [ForeignKey("IpraId")]
    [InverseProperty("IpraHelpCategories")]
    public virtual Ipra Ipra { get; set; } = null!;

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("IpraHelpCategoryModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;
}