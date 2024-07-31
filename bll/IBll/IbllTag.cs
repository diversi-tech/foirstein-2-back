using BL.BLApi;
using BLL.BllModels;

namespace BLL.IBll
{
    public interface IbllTag : IblCrud<BllTag>
    {
        public Task<List<BllTag>> ReadAll(int itemId);
    }
}
