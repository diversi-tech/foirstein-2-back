using System;
using System.Collections.Generic;

namespace dal.Modles;

public partial class Item
{
    public int ItemId { get; set; }

    public string Title { get; set; } = null!;

    public string? Author { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? FilePath { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; } = new List<ApprovalRequest>();

    public virtual ICollection<BorrowRequest> BorrowRequests { get; set; } = new List<BorrowRequest>();

    public virtual ICollection<RatingNote> RatingNotes { get; set; } = new List<RatingNote>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
