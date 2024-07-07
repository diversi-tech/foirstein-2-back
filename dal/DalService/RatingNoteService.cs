using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using dal.models;
using DAL.IDal;

namespace DAL.DalService
{
    public class RatingService:IRatingNote
    {
        LiberiansDbContext libraryContext;
        public RatingService(LiberiansDbContext libraryContext)
        {

            this.libraryContext = libraryContext;

        }

        public async Task<RatingNote> GetByUserAndItem(int userId, int itemId)
        {
            return await libraryContext.RatingNotes.FirstOrDefaultAsync(r => r.UserId == userId && r.ItemId == itemId);
        }

        public async Task<bool> Create(RatingNote item)
        {
            try
            {
                libraryContext.RatingNotes.Add(item);
                await libraryContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<bool> Delete(RatingNote item)
        {
            throw new NotImplementedException();
        }

        public Task<List<RatingNote>> Read(Func<RatingNote, bool> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RatingNote>> ReadAll()
        {
            throw new NotImplementedException();
        }
        public Task<RatingNote> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(RatingNote item)
        {
            int i = libraryContext.RatingNotes.ToList().FindIndex(r => r.RatingNoteId == item.RatingNoteId);
            if (i != -1)
            {
                var item1 = libraryContext.RatingNotes.ToList()[i];
                item1.Rating = item.Rating;
                item1.Note = item.Note;
                await libraryContext.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}
