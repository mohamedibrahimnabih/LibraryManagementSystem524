using System;
using System.Collections.Generic;

namespace Linq.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public DateOnly Dob { get; set; }

    public bool Gender { get; set; }

    public virtual ICollection<UserBook> UserBooks { get; set; } = new List<UserBook>();
}
