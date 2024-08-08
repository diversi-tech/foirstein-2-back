using BL.BLApi;
using BLL.BllModels;

namespace BLL.IBll
{
    public interface IbllRatingNote : IblCrud<BllRatingNote>
    {
        Task<BllRatingNote> getRatingNote(int userId, int itemId);
    }
}
