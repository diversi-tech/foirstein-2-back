using BL.BLApi;
using BLL.BllModels;

namespace BLL.IBll
{
    public interface IbllItemTag : IblCrud<BllItemTag>
    {
        public Task<List<BllItemTag>> ReadAll(int itemId);
    }
}
