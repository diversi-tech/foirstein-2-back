using BL.BLApi;
using BLL.BllModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IBll
{
    public interface IbllBorrowRequest : IblCrud<BllBorrowRequest>
    {

        Task<List<BllBorrowRequest>> Read(int filter);
        Task<List<BllBorrowRequest>> getAllItemToUser(int filter);
        Task<bool> deletRequest(int id);

        public interface IBorrowRequests : IblCrud<BllBorrowRequest>
        {
            Task<List<BllBorrowRequest>> Read(int filter);
            Task<List<BllItem>> getAllItemToUser(int filter);
            Task<bool> deletRequest(int id);

        }
    }
}
