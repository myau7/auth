using System;
using System.Collections.Generic;

namespace UsmanovBochkarev.Models;

public partial class Student
{
    public int Id { get; set; }

    public int GroupsId { get; set; }

    public string? SurnameStudents { get; set; }

    public string? NameStudents { get; set; }

    public string? MiddleOfNameStudents { get; set; }

    public DateTime? Birthday { get; set; }

    public virtual Group Groups { get; set; } = null!;

    public virtual ICollection<Parent> Parents { get; set; } = new List<Parent>();
}
