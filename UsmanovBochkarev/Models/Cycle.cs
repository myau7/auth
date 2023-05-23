using System;
using System.Collections.Generic;

namespace UsmanovBochkarev.Models;

public partial class Cycle
{
    public int Id { get; set; }

    public int AcademicPlan { get; set; }

    public string? NameCycle { get; set; }

    public virtual AcademicPlan AcademicPlanNavigation { get; set; } = null!;

    public virtual ICollection<DisciplineinAcademicPlan> DisciplineinAcademicPlans { get; set; } = new List<DisciplineinAcademicPlan>();
}
