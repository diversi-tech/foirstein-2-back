﻿using System;
using System.Collections.Generic;

namespace DAL.models;


public partial class Report
{
    public int ReportId { get; set; }

    public string ReportName { get; set; } = null!;

    public string ReportData { get; set; } = null!;

    public string? GeneratedBy { get; set; }

    public DateTime? GeneratedAt { get; set; }

    public int? GeneratedByNavigationUserId { get; set; }

    public virtual User? GeneratedByNavigationUser { get; set; }
}
