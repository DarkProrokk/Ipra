using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

[Table("Buro")]
public class Buro
{
    [Key] public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Shortname { get; set; }

    public string? Fullname { get; set; }

    public int? IdMse { get; set; }

    [Column(TypeName = "datetime")] public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("BuroCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [InverseProperty("Buro")] public virtual ICollection<Ipra> Ipras { get; set; } = new List<Ipra>();

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("BuroModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;
}