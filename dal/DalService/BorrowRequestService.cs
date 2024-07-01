using dal.models;
using DAL.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalService
{
    public class BorrowRequestService : IBorrowRequest
    {
        public Task<bool> Create(BorrowRequest item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(BorrowRequest item)
        {
            throw new NotImplementedException();
        }

        public Task<List<BorrowRequest>> Read(Func<BorrowRequest, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<BorrowRequest>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<BorrowRequest> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(BorrowRequest item)
        {
            throw new NotImplementedException();
        }
    }
}
