using dal.models;
using DAL.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalService
{
    public class SearchLogService : ISearchLog
    {
        public Task<bool> Create(SearchLog item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(SearchLog item)
        {
            throw new NotImplementedException();
        }

        public Task<List<SearchLog>> Read(Func<SearchLog, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<SearchLog>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<SearchLog> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(SearchLog item)
        {
            throw new NotImplementedException();
        }
    }
}
