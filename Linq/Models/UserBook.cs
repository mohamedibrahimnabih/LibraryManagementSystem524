using System;
using System.Collections.Generic;

namespace Linq.Models;

public partial class UserBook
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public virtual Book Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
