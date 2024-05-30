using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IpraAspNet.Domain.Entities;

public class GroupsTask
{
    [Key] public int Id { get; set; }

    [Column(TypeName = "datetime")] public DateTime CreatedTS { get; set; }

    public int UserId { get; set; }

    public string FolderName { get; set; } = null!;

    [InverseProperty("GroupTask")] public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();

    [ForeignKey("UserId")]
    [InverseProperty("GroupsTasks")]
    public virtual User User { get; set; } = null!;
}