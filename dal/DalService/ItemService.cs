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
        private LiberiansDbContext _context;

        public ItemService(LiberiansDbContext context)
        {
            _context = context;
            }
     
        public Task<bool> Create(Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Item item)
        {
            try
            {
                Item item1 = _context.Items.ToList().Find(t => t.Id == item.Id);
                _context.Items.Remove(item1);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Item>> ReadByString(string searchKey)
        {
           return 
                _context.Items.Where(item => EF.Functions.Like(item.Title, "%" + searchKey + "%") ||
                                            EF.Functions.Like(item.Description, "%" + searchKey + "%") ||
                                            EF.Functions.Like(item.Category, "%" + searchKey + "%") ||
                                            EF.Functions.Like(item.Author, "%" + searchKey + "%")).ToList();

        }


        public async Task<List<Item>> Read(Func<Item, bool> filter)
        {
            return _context.Items.Where(filter).ToList();
        }

       

        public async Task<List<Item>> ReadAll() => _context.Items.ToList();


        public async Task<Item> ReadbyId(int idItem)
        {
            Item? item = _context.Items.ToList().Find(t => t.Id == idItem);
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
