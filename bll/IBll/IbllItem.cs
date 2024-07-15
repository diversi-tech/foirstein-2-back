using BL.BLApi;
using BLL.BllModels;
using dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IBll
{
    public interface IbllItem : IblCrud<BllItem>
    {
        Task<IEnumerable<BllItem>> ReadByString(String searchKey);
        Task<IEnumerable<BllItem>> ReadByCategory(String category);
        Task<IEnumerable<BllItem>> ReadByAttributes(BllItem searchItem);


    }
}
