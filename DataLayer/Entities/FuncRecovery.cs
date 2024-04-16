using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

[Table("FuncRecovery")]
public class FuncRecovery
{
    [Key] public int Id { get; set; }

    [StringLength(50)] public string Name { get; set; } = null!;

    public int IdMse { get; set; }

    [Column(TypeName = "datetime")] public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("FuncRecoveryCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [InverseProperty("PrognozRecovery")] public virtual ICollection<Ipra> Ipras { get; set; } = new List<Ipra>();

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("FuncRecoveryModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;
}