using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

[Table("AddressType")]
public class AddressType
{
    [Key] public int Id { get; set; }

    [StringLength(100)] public string Name { get; set; } = null!;

    public int IdMse { get; set; }

    [Column(TypeName = "datetime")] public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("AddressTypeCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [InverseProperty("LivingAddressType")]
    public virtual ICollection<Ipra> IpraLivingAddressTypes { get; set; } = new List<Ipra>();

    [InverseProperty("RegAddressType")]
    public virtual ICollection<Ipra> IpraRegAddressTypes { get; set; } = new List<Ipra>();

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("AddressTypeModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;
}