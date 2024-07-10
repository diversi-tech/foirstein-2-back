using AutoMapper;
using BL.BLApi;
using BLL.BllModels;
using BLL.IBll;
using dal.models;
using DAL;

namespace BLL.BllServices
{
    public class BllRatingNoteService : IbllRatingNote
    {
        private IMapper _mapper;
        private readonly DalManager _dalManager;

        public BllRatingNoteService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            _mapper = new Mapper(config);
            _dalManager = new DalManager();
        }

        public BllRatingNoteService(IMapper mapper, DalManager dalManager)
        {
            _mapper = mapper;
            _dalManager = dalManager;
        }

        public async Task<BllRatingNote> getRatingNote(int userId, int itemId)
        {
            try
            {
                RatingNote matchingRatingNote = await _dalManager.ratingNote.GetByUserAndItem(userId, itemId);

                if (matchingRatingNote != null)
                {
                    return _mapper.Map<BllRatingNote>(matchingRatingNote);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(BllRatingNote ratingNote)
        {
            try
            {
                if (ratingNote.Rating.HasValue && (ratingNote.Rating < 0 || ratingNote.Rating > 5))
                {
                    throw new Exception("rating must be between 0 to 5");
                }

                if (ratingNote.Note != null && ratingNote.Note.Length > 255)
                {
                    throw new Exception("note can be maximum 255 chars");
                }

                RatingNote matchingRatingNote = await _dalManager.ratingNote.GetByUserAndItem(ratingNote.UserId, ratingNote.ItemId ?? 0);

                if (matchingRatingNote != null)
                {
                    matchingRatingNote.Rating = ratingNote.Rating;
                    matchingRatingNote.Note = ratingNote.Note;
                    bool b = await _dalManager.ratingNote.Update(matchingRatingNote);
                }
                else
                {
                    RatingNote newRatingNote = _mapper.Map<RatingNote>(ratingNote);
                    await _dalManager.ratingNote.Create(newRatingNote);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Create(BllRatingNote item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(BllRatingNote item)
        {
            throw new NotImplementedException();
        }

        public Task<List<BllRatingNote>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<BllRatingNote> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        public Task<List<BllRatingNote>> Read(Func<BllRatingNote, bool> filter)
        {
            throw new NotImplementedException();
        }

        Task<BllRatingNote> IblCrud<BllRatingNote>.ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        Task<List<BllRatingNote>> IblCrud<BllRatingNote>.ReadAll()
        {
            throw new NotImplementedException();
        }

    }
}
