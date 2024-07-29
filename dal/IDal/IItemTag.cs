using dal.models;
using DAL.DalApi;

namespace DAL.IDal
{
    public interface IItemTag : IblCrud<ItemTag>
    {
        public Task<List<ItemTag>> ReadAll(int itemId);
    }
}
