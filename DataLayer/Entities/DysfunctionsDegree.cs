using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

public partial class DysfunctionsDegree
{
    [Key]
    public int Id { get; set; }

    public int? Vision { get; set; }

    public int? Hearing { get; set; }

    public int? VisionAndHearing { get; set; }

    public int? UpperLimbs { get; set; }

    public int? BottomLimbs { get; set; }

    public int? WheelChair { get; set; }

    public int? Intellect { get; set; }

    public int? Lingual { get; set; }

    public int? BloodCirculation { get; set; }

    public int? Breath { get; set; }

    public int? Digestive { get; set; }

    public int? Metabolism { get; set; }

    public int? BloodAndImmune { get; set; }

    public int? Excretory { get; set; }

    public int? Skin { get; set; }

    public int? PhisicalDysfunction { get; set; }

    [InverseProperty("DD")]
    public virtual ICollection<Ipra> Ipras { get; set; } = new List<Ipra>();
}
