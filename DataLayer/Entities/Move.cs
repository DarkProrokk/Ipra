using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

[Table("Move")]
public class Move
{
    [Key] public int Id { get; set; }

    [StringLength(50)] public string Name { get; set; } = null!;

    [Column(TypeName = "datetime")] public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("MoveCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [InverseProperty("Move")]
    public virtual ICollection<IpraMovesHistory> IpraMovesHistories { get; set; } = new List<IpraMovesHistory>();

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("MoveModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;
}