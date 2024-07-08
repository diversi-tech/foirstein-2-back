using BL.BLApi;
using BLL.BllModels;
<<<<<<< HEAD
using dal.models;
=======
>>>>>>> 75dbee4dcd34de6bb03d90723fe1c7e093864762
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IBll
{
<<<<<<< HEAD
    public interface IbllItem : IblCrud<BllItem>
    {
        Task<IEnumerable<BllItem>> ReadByString(String searchKey);
=======
     public interface IbllItem : IblCrud<BLLItem>
    {
        Task<List<BLLItem>> Read(int filter);
>>>>>>> 75dbee4dcd34de6bb03d90723fe1c7e093864762

    }
}
