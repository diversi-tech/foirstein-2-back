using AutoMapper;
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

namespace BLL.BllService
{
    public class BllItemService : IbllItem
    {
        private DalManager _dalManager;
        private IMapper _mapper;
        public BllItemService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            _mapper = new Mapper(config);
            _dalManager = new DalManager();
        }

        public BllItemService(IMapper mapper, DalManager dalManager)
        {
            _mapper = mapper;
            _dalManager = dalManager;
        }

        public void MapItem()
        {
            BllItem bllRequest = new BllItem
            {
            };
            Item dalRequest = _mapper.Map<Item>(bllRequest);
        }

        public Task<bool> Create(BllItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(BllItem item)
        {
            throw new NotImplementedException();
        }

        public Task<List<BllItem>> Read(Func<BllItem, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<BllItem>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<BllItem> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BllItem>> ReadByString(string searchKey)
        {
            try
            {
                var dalItem = await _dalManager.items.ReadByString(searchKey);

                var bllItem = dalItem.Select(item => _mapper.Map<BllItem>(item)).ToList();

                return bllItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch Items", ex);
            }
        }
        public async Task<IEnumerable<BllItem>> ReadByAttributes(BllItem searchItem)
        {
            try
            {
                var dalItem = await _dalManager.items.ReadByAttributes(_mapper.Map<Item>(searchItem));

                var bllItem = dalItem.Select(item => _mapper.Map<BllItem>(item)).ToList();

                return bllItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch Items by attributes", ex);
            }
        }
        public Task<bool> Update(BllItem item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BllItem>> ReadByCategory(string category)
        {
            try
            {
                var dalItem = await _dalManager.items.ReadByCategory(category);

                var bllItem = dalItem.Select(item => _mapper.Map<BllItem>(item)).ToList();

                return bllItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch ItemTags", ex);
            }
        }


    }
}
