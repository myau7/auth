using System;
using System.Collections.Generic;

namespace UsmanovBochkarev.Models;

public partial class Parent
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public string? NameParents { get; set; }

    public string? SurnameParents { get; set; }

    public string? MiddleOfNameParents { get; set; }

    public virtual Student Student { get; set; } = null!;
}
