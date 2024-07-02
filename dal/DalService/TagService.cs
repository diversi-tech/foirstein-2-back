using dal.models;
using DAL.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalService
{
    public class TagService : ITag
    {
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

        public Task<List<Tag>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<Tag> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Tag item)
        {
            throw new NotImplementedException();
        }
    }
}
