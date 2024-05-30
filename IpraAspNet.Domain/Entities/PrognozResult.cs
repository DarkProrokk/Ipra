using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IpraAspNet.Domain.Entities;

[Table("PrognozResult")]
public class PrognozResult
{
    [Key] public int Id { get; set; }

    public int? FuncRecovery { get; set; }

    public int? FuncCompensation { get; set; }

    public int? SelfService { get; set; }

    public int? MoveIndependently { get; set; }

    public int? Orientate { get; set; }

    public int? Communicate { get; set; }

    public int? BehaviorControl { get; set; }

    public int? Learning { get; set; }

    public int? Work { get; set; }

    [InverseProperty("PR")] public virtual ICollection<Ipra> Ipras { get; set; } = new List<Ipra>();
}