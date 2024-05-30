using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IpraAspNet.Domain.Entities;

public class UserMO
{
    [Key] public int UserMOsId { get; set; }

    public int UserId { get; set; }

    public int? MOId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("UserMOCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [ForeignKey("MOId")]
    [InverseProperty("UserMOs")]
    public virtual MO? MO { get; set; }

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("UserMOModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserMOUsers")]
    public virtual User User { get; set; } = null!;
}