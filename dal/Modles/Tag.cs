using System;
using System.Collections.Generic;

namespace dal.Modles;

public partial class Tag
{
    public int TagId { get; set; }

    public string TagName { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
