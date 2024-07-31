using System;
using System.Collections.Generic;

namespace DAL.models;


public partial class SearchLog
{
    public int LogId { get; set; }

    public int UserId { get; set; }

    public string SearchQuery { get; set; } = null!;

    public DateTime? SearchDate { get; set; }

    public virtual User User { get; set; } = null!;
}
