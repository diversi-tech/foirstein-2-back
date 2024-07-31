using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BllModels
{
    public class BllItem
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? Category { get; set; }

        public string FilePath { get; set; } = null!;

        public bool IsApproved { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int PublishingYear { get; set; }

        public string? Edition { get; set; }

        public string? Series { get; set; }

        public int? NumOfSeries { get; set; }

        public string? Language { get; set; }

        public string? Note { get; set; }

        public string? AccompanyingMaterial { get; set; }

        public int? ItemLevel { get; set; }

        public string? HebrewPublicationYear { get; set; }

        public int? NumberOfDaysOfQuestion { get; set; }

        public bool Recommended { get; set; }

        public int? UserId { get; set; }

        public int Amount { get; set; }

        public int ItemType { get; set; }
    }
}
