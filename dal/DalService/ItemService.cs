using dal.models;
using DAL.DalApi;
using DAL.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalService
{
    public class ItemService : IItem
    {
        private LiberiansDbContext db;

        public ItemService(LiberiansDbContext db)
        {
            this.db = db;
        }
        public Task<bool> Create(Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Item item)
        {
            try
            {
                Item item1 = db.Items.ToList().Find(t => t.Id == item.Id);
                db.Items.Remove(item1);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Item>> Read(Func<Item, bool> filter)
        {
            return db.Items.Where(filter).ToList();
        }

       

        public async Task<List<Item>> ReadAll() => db.Items.ToList();


        public async Task<Item> ReadbyId(int idItem)
        {
            Item? item = db.Items.ToList().Find(t => t.Id == idItem);
            return item;
        }

        public Task<bool> Update(Item item)
        {
            throw new NotImplementedException();
        }

        Task<List<Item>> ICrud<Item>.ReadAll()
        {
            throw new NotImplementedException();
        }
    }
}
