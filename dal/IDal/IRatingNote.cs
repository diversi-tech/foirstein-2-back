using dal.models;
//using dal.Modles;
using DAL.DalApi;

namespace DAL.IDal
{
    public interface IRatingNote : IblCrud<RatingNote>
    {
        Task<RatingNote> GetByUserAndItem(int userId, int itemId);
    }
}
