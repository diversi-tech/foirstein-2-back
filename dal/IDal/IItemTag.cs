using DAL.DalApi;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DalApi;

namespace DAL.IDal
{
    public interface IItemTag : IblCrud<ItemTag>
    {
        public Task<List<ItemTag>> ReadAll(int itemId);
    }
}
