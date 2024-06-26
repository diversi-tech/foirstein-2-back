using System;
using System.Collections.Generic;

namespace dal.Modles;

public partial class Report
{
    public int ReportId { get; set; }

    public string ReportName { get; set; } = null!;

    public string ReportData { get; set; } = null!;

    public string? GeneratedBy { get; set; }

    public DateTime? GeneratedAt { get; set; }

    public virtual User? GeneratedByNavigation { get; set; }
}
