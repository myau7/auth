using System;
using System.Collections.Generic;

namespace UsmanovBochkarev.Models;

public partial class User
{
    public int Id { get; set; }

    public string? LoginUser { get; set; }

    public string? PasswordUser { get; set; }

    public string? SurnameUser { get; set; }

    public string? NameUser { get; set; }

    public string? MiddleName { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
