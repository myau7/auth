using System;
using System.Collections.Generic;

namespace UsmanovBochkarev.Models;

public partial class Post
{
    public int Id { get; set; }

    public string? NamePost { get; set; }

    public virtual ICollection<AccessPermission> AccessPermissions { get; set; } = new List<AccessPermission>();
}
