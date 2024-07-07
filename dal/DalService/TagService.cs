using dal.models;
using DAL.IDal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalService
{
    public class TagService : ITag
    {
        LiberiansDbContext _context;

        public TagService(LiberiansDbContext context)
        {
            this._context = context;
        }

        public Task<bool> Create(Tag item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Tag item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tag>> Read(Func<Tag, bool> filter)
        {
            throw new NotImplementedException();
        }

        //public Task<List<Tag>> ReadAll() => _context.Tags.ToList();
        public Task<List<Tag>> ReadAll()
        {
            throw new NotImplementedException(); 
        }


        public async Task<Tag> ReadbyId(int item)
        {
            return _context.Tags.ToList().Find(t => t.Id == item);
        }

        public Task<bool> Update(Tag item)
        {
            throw new NotImplementedException();
        }
    }
}
