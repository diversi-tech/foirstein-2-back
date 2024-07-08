using BL.BLApi;
using BLL.BllModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IBll
{
<<<<<<< HEAD
    public interface IbllBorrowRequest : IblCrud<BllBorrowRequest>
    {

        Task<List<BllBorrowRequest>> Read(int filter);
        Task<List<BllBorrowRequest>> getAllItemToUser(int filter);
=======
     public interface IBorrowRequests : IblCrud<BllBorrowRequest>
    {
        Task<List<BllBorrowRequest>> Read(int filter);
        Task<List<BLLItem>> getAllItemToUser(int filter);
>>>>>>> 75dbee4dcd34de6bb03d90723fe1c7e093864762
        Task<bool> deletRequest(int id);

    }
}
