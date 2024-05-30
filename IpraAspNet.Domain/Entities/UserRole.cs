using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IpraAspNet.Domain.Entities;

public class UserRole
{
    [Key] public int UserRolesId { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("UserRoleCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("UserRoleModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("UserRoles")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserRoleUsers")]
    public virtual User User { get; set; } = null!;
}