using System;
using System.Collections.Generic;

namespace dal.Modles;

public partial class SearchLog
{
    public int LogId { get; set; }

    public string? UserId { get; set; }

    public string SearchQuery { get; set; } = null!;

    public DateTime? SearchDate { get; set; }

    public virtual User? User { get; set; }
}
