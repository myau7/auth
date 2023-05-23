using System;
using System.Collections.Generic;

namespace UsmanovBochkarev.Models;

public partial class AccessPermission
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public string? Permission { get; set; }

    public virtual Post Post { get; set; } = null!;
}
