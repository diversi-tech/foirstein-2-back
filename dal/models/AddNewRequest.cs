using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class AddNewRequest
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;

    public bool IsApproved { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? PublishigYear { get; set; }

    public string Edition { get; set; } = null!;

    public string Series { get; set; } = null!;

    public int? NumOfSeries { get; set; }

    public string Language { get; set; } = null!;

    public string Note { get; set; } = null!;

    public string AccompanyingMaterial { get; set; } = null!;

    public string HebrewPublicationYear { get; set; } = null!;

    public int UserId { get; set; }

    public int Amount { get; set; }

    public int ItemType { get; set; }

    public int? ItemLevel { get; set; }
}
