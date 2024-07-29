using AutoMapper;
using BLL.BllModels;
using BLL.IBll;
using dal.models;
using DAL;

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

        public async Task<List<BllItem>> ReadAll()
        {
            try
            {
                var dalItem = await _dalManager.items.ReadAll();

                var bllItem = dalItem.Select(item => _mapper.Map<BllItem>(item)).ToList();

                return bllItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to find all Items", ex);
            }
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
                throw new Exception("Failed to fetch items by category ", ex);
            }
        }

        public async Task<IEnumerable<BllItem>> ReadTheRecommended()
        {
            try
            {
                var dalItem = await _dalManager.items.ReadTheRecommended();

                var bllItem = dalItem.Select(item => _mapper.Map<BllItem>(item)).ToList();

                return bllItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to find recommendations", ex);
            }
        }

        public async Task<IEnumerable<BllItem>> ReadByTag(int tagId)

        {

            try

            {
                var dalItems = await _dalManager.items.ReadByTag(tagId);

                var bllItems = dalItems.Select(item => _mapper.Map<BllItem>(item)).ToList();

                return bllItems;

            }

            catch (Exception ex)

            {

                throw new Exception("Failed to fetch items by tag", ex);

            }

        }

        public async Task<IEnumerable<BllItem>> ReadMostRequested()
        {
            try
            {
                var dalItem = await _dalManager.items.ReadMostRequested();

                var bllItem = dalItem.Select(item => _mapper.Map<BllItem>(item)).ToList();

                return bllItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch MostRequested", ex);
            }
        }
    }
}
