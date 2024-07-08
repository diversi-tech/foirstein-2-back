using System;
using System.Collections.Generic;

namespace BLL.BllModels;

public partial class BLLItem
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

  
}
