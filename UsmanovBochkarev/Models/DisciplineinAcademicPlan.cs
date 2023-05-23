using System;
using System.Collections.Generic;

namespace UsmanovBochkarev.Models;

public partial class DisciplineinAcademicPlan
{
    public int Id { get; set; }

    public int CycleId { get; set; }

    public int AcademicDisciplineId { get; set; }

    public DateTime? Time { get; set; }

    public string? NameDisciplineinAcademicPlan { get; set; }

    public int? SemesterNumber { get; set; }

    public virtual AcademicDiscipline AcademicDiscipline { get; set; } = null!;

    public virtual Cycle Cycle { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
