using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IpraAspNet.Domain.Entities;

[Table("DocType")]
public class DocType
{
    [Key] public int Id { get; set; }

    [StringLength(100)] public string Name { get; set; } = null!;

    [Column(TypeName = "datetime")] public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("DocTypeCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [InverseProperty("RepresentativeAuthDocTypeNavigation")]
    public virtual ICollection<Ipra> IpraRepresentativeAuthDocTypeNavigations { get; set; } = new List<Ipra>();

    [InverseProperty("RepresentativeIdentDocTypeNavigation")]
    public virtual ICollection<Ipra> IpraRepresentativeIdentDocTypeNavigations { get; set; } = new List<Ipra>();

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("DocTypeModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;
}