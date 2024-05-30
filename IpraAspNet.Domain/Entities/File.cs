using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IpraAspNet.Domain.Entities;

[Table("Files")]
public class Files
{
    [Key] public int id { get; set; }

    public string Path { get; set; } = null!;

    [Column(TypeName = "datetime")] public DateTime? CreatedTS { get; set; }

    public int? PatientId { get; set; }

    [InverseProperty("Files")] public virtual ICollection<Ipra> Ipras { get; set; } = new List<Ipra>();

    [ForeignKey("PatientId")]
    [InverseProperty("Files")]
    public virtual Patient? Patient { get; set; }

    [InverseProperty("Files")] public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}