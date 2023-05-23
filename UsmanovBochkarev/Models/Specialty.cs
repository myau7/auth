using System;
using System.Collections.Generic;

namespace UsmanovBochkarev.Models;

public partial class Specialty
{
    public int Id { get; set; }

    public int CathedraId { get; set; }

    public string? NameSpeciality { get; set; }

    public int? Code { get; set; }

    public virtual ICollection<Applicant> Applicants { get; set; } = new List<Applicant>();

    public virtual Сathedra Cathedra { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
