using AutoMapper;
using BL.BLApi;
using BLL.BllModels;
using BLL.IBll;
using dal.models;
using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BLL.BllService
{
    public class BllTagService : IbllTag
    {
        private DalManager dalManager;
        private IMapper mapper;
        public BllTagService()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MapperProfile>();
            });
            mapper = new Mapper(config);
            dalManager = new DalManager();
        }
        public BllTagService(IMapper mapper, DalManager dalManager)
        {
            mapper = mapper;
            dalManager = dalManager;
        }

        public void MapBorrowRequest()
        {
            BllTag bllRequest = new BllTag
            {
                // Set properties for bllRequest as needed
            };
            Tag dalRequest = mapper.Map<Tag>(bllRequest);
            // Use the mapped dalRequest object as needed
        }

        public Task<bool> Create(BllTag item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(BllTag item)
        {
            throw new NotImplementedException();
        }

        public Task<List<BllTag>> Read(Func<BllTag, bool> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<BllTag> ReadbyId(int item)
        {
            var tag = await dalManager.Tags.ReadbyId(item);
            return mapper.Map<BllTag>(tag);
        }

        public async Task<List<BllTag>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<BllTag>> ReadAll(int itemId)
        {
            try
            {
                List<BllTag> tagList = new List<BllTag>();
                var dalItemTags = await dalManager.ItemTags.ReadAll(itemId);
                //var dalItemTags = dalManager;
                //var a = dalManager.ItemTags;
                //var b = dalManager.ItemTags.ReadAll(1);
                var bllItemTags = dalItemTags.Select(tag => mapper.Map<BllItemTag>(tag)).ToList();

                foreach (var itemTag in bllItemTags)
                {
                    var tag = await this.ReadbyId(itemTag.TagId);
                    var bllTag = mapper.Map<BllTag>(tag);
                    tagList.Add(bllTag);
                }

                return tagList;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch Tags", ex);
            }
        }



        public Task<bool> Update(BllTag item)
        {
            throw new NotImplementedException();
        }

      
    }
}
