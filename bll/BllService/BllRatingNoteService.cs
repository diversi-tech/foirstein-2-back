using AutoMapper;
using BL;
using BL.BLApi;
using BLL.BllModels;
using BLL.IBll;

using dal.models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BLL.BllServices
{
    public class BllRatingService:IbllRatingNote
    {
        private IMapper _mapper;
        private readonly DalManager _dalManager;

        public BllRatingService()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MapperProfile>();
                // Add any additional mapping configurations here
            });
            _mapper = new Mapper(config);
            _dalManager = new DalManager();
        }

        public BllRatingService(IMapper mapper, DalManager dalManager)
        {
            _mapper = mapper;
            _dalManager = dalManager;
        }

        public async Task<BllRatingNote> getRatingNote(int userId, int itemId)
        {
            RatingNote matchingRatingNote = await _dalManager.ratingNote.GetByUserAndItem(userId, itemId);

            if (matchingRatingNote != null)
            {
                //return await casting(matchingRatingNote);
                return _mapper.Map<BllRatingNote>(matchingRatingNote);
            }
            else
            {
                return null;
            }
        }

          public async Task<bool> Update(BllRatingNote ratingNote)
        {
            RatingNote matchingRatingNote = await _dalManager.ratingNote.GetByUserAndItem(ratingNote.UserId, ratingNote.ItemId??0);

            if (matchingRatingNote != null)
            {
                //RatingNote newRatingNote = _mapper.Map<RatingNote>(ratingNote);
                matchingRatingNote.Rating = ratingNote.Rating;
                matchingRatingNote.Note = ratingNote.Note;
                bool b = await _dalManager.ratingNote.Update(matchingRatingNote);
            }
            else
            {
                RatingNote newRatingNote = _mapper.Map<RatingNote>(ratingNote);
                bool b= await _dalManager.ratingNote.Create(newRatingNote);
            }
            return true;
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
