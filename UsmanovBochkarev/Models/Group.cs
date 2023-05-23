using System;
using System.Collections.Generic;

namespace UsmanovBochkarev.Models;

public partial class Group
{
    public int Id { get; set; }

    public int UserIdCurator { get; set; }

    public int SpecialtyId { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual Specialty Specialty { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual User UserIdCuratorNavigation { get; set; } = null!;
}
