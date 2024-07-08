using AutoMapper;
using BL.BLApi;
using BLL.BllModels;
using BLL.IBll;
using dal.models;
using DAL;
using DAL.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BllService
{
    public class BllItemTagService : IbllItemTag
    {
        private DalManager dalManager;
        private IMapper mapper;
        public BllItemTagService()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MapperProfile>();
            });
            mapper = new Mapper(config);
            dalManager = new DalManager();
        }
        public BllItemTagService(IMapper mapper, DalManager dalManager)
        {
            mapper = mapper;
            dalManager = dalManager;
        }

        public void MapBorrowRequest()
        {
            BllItemTag bllRequest = new BllItemTag
            {
                // Set properties for bllRequest as needed
            };
            ItemTag dalRequest = mapper.Map<ItemTag>(bllRequest);
            // Use the mapped dalRequest object as needed
        }

        public Task<bool> Create(BllItemTag item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(BllItemTag item)
        {
            throw new NotImplementedException();
        }

        public Task<List<BllItemTag>> Read(Func<BllItemTag, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task<BllItemTag> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BllItemTag>> ReadAll()
        {
            throw new NotImplementedException();
        }
        public async Task<List<BllItemTag>> ReadAll(int itemId)
        {
            try
            {
                var dalItemTags = await dalManager.ItemTags.ReadAll(itemId);

                var bllItemTags = dalItemTags.Select(tag => mapper.Map<BllItemTag>(tag)).ToList();

                return bllItemTags;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch ItemTags", ex);
            }
        }


        public Task<bool> Update(BllItemTag item)
        {
            throw new NotImplementedException();
        }

       
    }

}
