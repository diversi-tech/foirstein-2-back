using System;
using System.Collections.Generic;

namespace dal.models;

public partial class Item
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public bool IsApproved { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<BorrowRequest> BorrowRequests { get; set; } = new List<BorrowRequest>();

    public virtual ICollection<ItemTag> ItemTags { get; set; } = new List<ItemTag>();

    public virtual ICollection<RatingNote> RatingNotes { get; set; } = new List<RatingNote>();
}
