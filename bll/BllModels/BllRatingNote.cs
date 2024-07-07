using dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.BllModels
{

    public class BllRatingNote
    {
        public int RatingNoteId { get; set; }

        public int UserId { get; set; }

        public int? ItemId { get; set; }

        public string? Note { get; set; }

        public int? Rating { get; set; }

        public BllRatingNote(int RatingNoteId, int UserId, int? ItemId, string? Note, int? Rating)
        {
            this.RatingNoteId = RatingNoteId;
            this.UserId = UserId;
            this.ItemId = ItemId;
            this.Note = Note;
            this.Rating = Rating;

        }
    }
}