using System;
using System.Collections.Generic;

namespace dal.models;

public partial class ItemTag
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public int TagId { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
