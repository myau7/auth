using System;
using System.Collections.Generic;

namespace UsmanovBochkarev.Models;

public partial class PostUser
{
    public int PostId { get; set; }

    public int PostUserId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User PostUserNavigation { get; set; } = null!;
}
