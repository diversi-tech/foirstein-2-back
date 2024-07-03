using dal.models;
using DAL.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalService
{
    public class ItemService : IItemTag
    {
        public Task<bool> Create(ItemTag item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ItemTag item)
        {
            throw new NotImplementedException();
        }

        public Task<List<ItemTag>> Read(Func<ItemTag, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<ItemTag>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<ItemTag> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ItemTag item)
        {
            throw new NotImplementedException();
        }
    }
}
