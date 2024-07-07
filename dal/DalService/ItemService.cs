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

        public Task<bool> Delete(Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> ReadByString(string searchKey)
        {
           return 
                _context.Items.Where(item => EF.Functions.Like(item.Title, "%" + searchKey + "%") ||
                                            EF.Functions.Like(item.Description, "%" + searchKey + "%") ||
                                            EF.Functions.Like(item.Category, "%" + searchKey + "%") ||
                                            EF.Functions.Like(item.Author, "%" + searchKey + "%")).ToList();

        }

        public Task<List<Item>> Read(Func<Item, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<Item> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
