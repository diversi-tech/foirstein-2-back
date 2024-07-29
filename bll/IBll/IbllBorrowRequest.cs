using BL.BLApi;
using BLL.BllModels;

namespace BLL.IBll
{
    public interface IbllBorrowRequest : IblCrud<BllBorrowRequest>
    {

        Task<List<BllBorrowRequest>> Read(int filter);
        Task<List<BllItem>> getAllItemToUser(int filter);
        Task<bool> deletRequest(int id);
        Task<dynamic> GetBorrowRequestsAndApprovals(int id);

        public interface IBorrowRequests : IblCrud<BllBorrowRequest>
        {
            Task<List<BllBorrowRequest>> Read(int filter);
            Task<List<BllItem>> getAllItemToUser(int filter);
            Task<bool> deletRequest(int id);

        }
    }
}
