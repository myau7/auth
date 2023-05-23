using System;
using System.Collections.Generic;

namespace UsmanovBochkarev.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public int OfficeId { get; set; }

    public int UserId { get; set; }

    public int GroupId { get; set; }

    public string? Order { get; set; }

    public DateTime? Date { get; set; }

    public int DisciplinInAcademicPlanId { get; set; }

    public virtual DisciplineinAcademicPlan DisciplinInAcademicPlan { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;

    public virtual Office Office { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
