using DAL.DalApi;
using DAL.models;

namespace DAL.IDal
{
    public interface IRatingNote : IblCrud<RatingNote>
    {
        Task<RatingNote> GetByUserAndItem(int userId, int itemId);
    }
}
