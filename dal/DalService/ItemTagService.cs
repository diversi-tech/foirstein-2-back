using dal.models;
using DAL.IDal;

namespace DAL.DalService
{
    public class ItemTagService : IItemTag
    {
        LiberiansDbContext _context;

        public ItemTagService(LiberiansDbContext context)
        {
            this._context = context;
        }
        public Task<bool> Create(ItemTag item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ItemTag item)
        {
            throw new NotImplementedException();
        }

        public Task<List<ItemTag>> Read(Func<ItemTag, bool> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ItemTag>> ReadAll()
        {
            throw new NotImplementedException();
        }
        public async Task<List<ItemTag>> ReadAll(int itemId)
        {
            return _context.ItemTags.Where(itemTag => itemTag.ItemId == itemId).ToList();
        }

        public Task<ItemTag> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ItemTag item)
        {
            throw new NotImplementedException();
        }
    }
}