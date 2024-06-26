using System;
using System.Collections.Generic;

namespace dal.Modles;

public partial class ApprovalRequest
{
    public int RequestId { get; set; }

    public int? ItemId { get; set; }

    public string? UserId { get; set; }

    public DateTime? RequestDate { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public string? Status { get; set; }

    public DateOnly? FromDate { get; set; }

    public DateOnly? UntilDate { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual Item? Item { get; set; }

    public virtual User? User { get; set; }
}
