using BL.BLApi;
using BLL.BllModels;

namespace BLL.IBll
{
    public interface IbllItem : IblCrud<BllItem>
    {
        Task<IEnumerable<BllItem>> ReadByString(String searchKey);
        Task<IEnumerable<BllItem>> ReadByCategory(String category);
        Task<IEnumerable<BllItem>> ReadByAttributes(BllItem searchItem);
        Task<IEnumerable<BllItem>> ReadTheRecommended();
        Task<IEnumerable<BllItem>> ReadByTag(int tagId);
        Task<IEnumerable<BllItem>> ReadMostRequested();



    }
}
