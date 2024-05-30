using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IpraAspNet.Domain.Entities;

[Table("RecipientType")]
public class RecipientType
{
    [Key] public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdMse { get; set; }

    [Column(TypeName = "datetime")] public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("RecipientTypeCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [InverseProperty("RecipientType")] public virtual ICollection<Ipra> Ipras { get; set; } = new List<Ipra>();

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("RecipientTypeModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;
}