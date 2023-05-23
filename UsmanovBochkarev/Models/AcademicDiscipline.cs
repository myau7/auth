using System;
using System.Collections.Generic;

namespace UsmanovBochkarev.Models;

public partial class AcademicDiscipline
{
    public int Id { get; set; }

    public string? FullNameOfDiscipline { get; set; }

    public string? ShortNameOfDiscipline { get; set; }

    public virtual ICollection<DisciplineinAcademicPlan> DisciplineinAcademicPlans { get; set; } = new List<DisciplineinAcademicPlan>();
}
