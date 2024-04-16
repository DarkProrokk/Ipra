using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

[Table("MO")]
public class MO
{
    [Key] public int Id { get; set; }

    [StringLength(100)] public string Shortname { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public int? LevelOmp { get; set; }

    [StringLength(6)] public string? FomsCode { get; set; }

    [StringLength(10)] public string? DbName { get; set; }

    public bool IsInMiac { get; set; }

    [Column(TypeName = "datetime")] public DateTime? CreatedTS { get; set; }

    public int CreatedUserId { get; set; }

    [Column(TypeName = "datetime")] public DateTime? ModifiedTS { get; set; }

    public int ModifiedUserId { get; set; }

    [StringLength(50)] public string? OidEgisz { get; set; }

    [StringLength(50)] public string? Ogrn { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("MOCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [InverseProperty("Mo")] public virtual ICollection<Ipra> IpraMos { get; set; } = new List<Ipra>();

    [InverseProperty("SenderMo")] public virtual ICollection<Ipra> IpraSenderMos { get; set; } = new List<Ipra>();

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("MOModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;

    [InverseProperty("MO")] public virtual ICollection<UserMO> UserMOs { get; set; } = new List<UserMO>();
}