using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

[Table("Tasks")]
public class Tasks
{
    [Key] public int Id { get; set; }

    public int FileId { get; set; }

    public int Status { get; set; }

    [Column(TypeName = "datetime")] public DateTime? CreatedTS { get; set; }

    [Column(TypeName = "datetime")] public DateTime? ModifiedTS { get; set; }

    [StringLength(50)] public string? SurnameMse { get; set; }

    [StringLength(50)] public string? NameMse { get; set; }

    [StringLength(50)] public string? LastnameMse { get; set; }

    [StringLength(50)] public string? SnilsMse { get; set; }

    public string? Message { get; set; }

    public int CreatedUserId { get; set; }

    public int ModifiedUserId { get; set; }

    [StringLength(36)] public string? PatientGuidMse { get; set; }

    public int? GroupTaskId { get; set; }

    [ForeignKey("CreatedUserId")]
    [InverseProperty("TaskCreatedUsers")]
    public virtual User CreatedUser { get; set; } = null!;

    [ForeignKey("FileId")]
    [InverseProperty("Tasks")]
    public virtual Files Files { get; set; } = null!;

    [ForeignKey("GroupTaskId")]
    [InverseProperty("Tasks")]
    public virtual GroupsTask? GroupTask { get; set; }

    [ForeignKey("ModifiedUserId")]
    [InverseProperty("TaskModifiedUsers")]
    public virtual User ModifiedUser { get; set; } = null!;
}