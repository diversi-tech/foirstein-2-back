using System;
using System.Collections.Generic;

namespace dal.Modles;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Email { get; set; }

    public string Role { get; set; } = null!;

    public string? ProfilePicture { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateOnly UserDob { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

    public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; } = new List<ApprovalRequest>();

    public virtual ICollection<BorrowRequest> BorrowRequests { get; set; } = new List<BorrowRequest>();

    public virtual ICollection<RatingNote> RatingNotes { get; set; } = new List<RatingNote>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<SearchLog> SearchLogs { get; set; } = new List<SearchLog>();
}
