using dal.models;
using DAL.DalApi;
using DAL.IDal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalService
{
    public class ItemService : IItem
    {
<<<<<<< HEAD
        private LiberiansDbContext _context;

        public ItemService(LiberiansDbContext context)
        {
            _context = context;
=======
        private LiberiansDbContext db;

        public ItemService(LiberiansDbContext db)
        {
            this.db = db;
>>>>>>> 75dbee4dcd34de6bb03d90723fe1c7e093864762
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

<<<<<<< HEAD
        public async Task<IEnumerable<Item>> ReadByString(string searchKey)
        {
           return 
                _context.Items.Where(item => EF.Functions.Like(item.Title, "%" + searchKey + "%") ||
                                            EF.Functions.Like(item.Description, "%" + searchKey + "%") ||
                                            EF.Functions.Like(item.Category, "%" + searchKey + "%") ||
                                            EF.Functions.Like(item.Author, "%" + searchKey + "%")).ToList();

        }

        public Task<List<Item>> Read(Func<Item, bool> filter)
=======
        public async Task<List<Item>> Read(Func<Item, bool> filter)
>>>>>>> 75dbee4dcd34de6bb03d90723fe1c7e093864762
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
