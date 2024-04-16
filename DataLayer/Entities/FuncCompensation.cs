using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

[Table("FuncCompensation")]
public class FuncCompensation
{
    [Key] public int Id { get; set; }

    [StringLength(50)] public string Name { get; set; } = null!;

    public int IdMse { get; set; }

    [Column(TypeName = "datetime")] public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("FuncCompensationCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [InverseProperty("PrognozCompensation")]
    public virtual ICollection<Ipra> Ipras { get; set; } = new List<Ipra>();

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("FuncCompensationModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;
}