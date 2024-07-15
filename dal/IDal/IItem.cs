using dal.models;
using DAL.DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IDal
{
    public interface IItem:ICrud<Item>
    {
        Task<IEnumerable<Item>> ReadByString(String searchKey);
        Task<IEnumerable<Item>> ReadByCategory(String category);
        Task<IEnumerable<Item>> ReadByAttributes(Item searchItem);

    }
}
