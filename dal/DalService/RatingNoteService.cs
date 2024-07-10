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
    public class RatingNoteService : IRatingNote
    {
        LiberiansDbContext libraryContext;
        public RatingNoteService(LiberiansDbContext libraryContext)
        {

            this.libraryContext = libraryContext;

        }

        public async Task<RatingNote> GetByUserAndItem(int userId, int itemId)
        {
            try
            {
                return await libraryContext.RatingNotes.FirstOrDefaultAsync(r => r.UserId == userId && r.ItemId == itemId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Create(RatingNote item)
        {
            try
            {
                await libraryContext.RatingNotes.AddAsync(item);
                await libraryContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
