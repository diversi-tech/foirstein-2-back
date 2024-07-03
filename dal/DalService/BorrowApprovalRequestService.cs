using dal.models;
using DAL.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalService
{
    public class BorrowApprovalRequestService : IBorrowApprovalRequest
    {
        public Task<bool> Create(BorrowApprovalRequest item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(BorrowApprovalRequest item)
        {
            throw new NotImplementedException();
        }

        public Task<List<BorrowApprovalRequest>> Read(Func<BorrowApprovalRequest, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<BorrowApprovalRequest>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<BorrowApprovalRequest> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(BorrowApprovalRequest item)
        {
            throw new NotImplementedException();
        }
    }
}
