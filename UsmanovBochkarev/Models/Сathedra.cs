using System;
using System.Collections.Generic;

namespace UsmanovBochkarev.Models;

public partial class Сathedra
{
    public int Id { get; set; }

    public string? NameCathedra { get; set; }

    public virtual ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
}
