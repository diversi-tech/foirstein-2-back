using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class LibrarianPermission
{
    public int UserId { get; set; }

    public List<string> Permissions { get; set; } = null!;

    public int Id { get; set; }

    public virtual User User { get; set; } = null!;
}
