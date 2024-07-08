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
    internal class ItemServer : IbllItem
    {
        private DalManager _dalManager;
        private IMapper mapper;


        public ItemServer(DalManager _dalManager)
        {
            this._dalManager = _dalManager;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            mapper = config.CreateMapper();
        }

        public Task<bool> Create(BLLItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(BLLItem item)
        {
            throw new NotImplementedException();
        }

        public Task<List<BLLItem>> Read(Func<BLLItem, bool> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BLLItem>> Read(int filter)
        {
            List<Item> items = await _dalManager.items.Read(br => br.Id == filter);
            return mapper.Map<List<Item>, List<BLLItem>>(items);
        }

        public Task<List<BLLItem>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public async Task<BLLItem> ReadbyId(int idItem)
        {
            Item item = await _dalManager.items.ReadbyId(idItem);
            return mapper.Map<Item , BLLItem> (item);
        }

        public Task<bool> Update(BLLItem item)
        {
            throw new NotImplementedException();
        }
    }
}
