using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IpraAspNet.Domain.Entities;

public class Role
{
    [Key] public int RoleId { get; set; }

    [StringLength(50)] [Unicode(false)] public string RoleName { get; set; } = null!;

    [StringLength(255)] [Unicode(false)] public string RoleDescription { get; set; } = null!;

    [Column(TypeName = "datetime")] public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("RoleCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("RoleModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;

    [InverseProperty("Role")] public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}