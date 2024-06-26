using System;
using System.Collections.Generic;

namespace dal.Modles;

public partial class RatingNote
{
    public int RatingNoteId { get; set; }

    public string? UserId { get; set; }

    public int? ItemId { get; set; }

    public string? Note { get; set; }

    public int? Rating { get; set; }

    public virtual Item? Item { get; set; }

    public virtual User? User { get; set; }
}
