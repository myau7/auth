using System;
using System.Collections.Generic;

namespace UsmanovBochkarev.Models;

public partial class AcademicPlan
{
    public int Id { get; set; }

    public string? NameAcademicPlan { get; set; }

    public virtual ICollection<Cycle> Cycles { get; set; } = new List<Cycle>();
}
