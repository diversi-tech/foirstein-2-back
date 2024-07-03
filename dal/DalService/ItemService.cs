using dal.models;
using DAL.DalApi;
using DAL.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalService
{
    public class ItemService : IItem
    {
        public Task<bool> Create(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> Read(Func<Item, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<Item> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
