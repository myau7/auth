using System;
using System.Collections.Generic;

namespace UsmanovBochkarev.Models;

public partial class Office
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public int? Stage { get; set; }

    public string? NameOffice { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
