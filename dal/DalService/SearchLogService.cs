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
    public class SearchLogService : ISearchLog
    {
        public Task<bool> Create(ISearchLog item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ISearchLog item)
        {
            throw new NotImplementedException();
        }

        public Task<List<ISearchLog>> Read(Func<ISearchLog, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<ISearchLog>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<ISearchLog> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ISearchLog item)
        {
            throw new NotImplementedException();
        }
    }
}
