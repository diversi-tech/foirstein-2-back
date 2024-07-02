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
    public class BorrowApprovalRequestService : IBorrowApprovalRequest
    {
        Task<bool> ICrud<BorrowApprovalRequest>.Create(BorrowApprovalRequest item)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICrud<BorrowApprovalRequest>.Delete(BorrowApprovalRequest item)
        {
            throw new NotImplementedException();
        }

        Task<List<BorrowApprovalRequest>> ICrud<BorrowApprovalRequest>.Read(Func<BorrowApprovalRequest, bool> filter)
        {
            throw new NotImplementedException();
        }

        Task<List<BorrowApprovalRequest>> ICrud<BorrowApprovalRequest>.ReadAll()
        {
            throw new NotImplementedException();
        }

        Task<BorrowApprovalRequest> ICrud<BorrowApprovalRequest>.ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICrud<BorrowApprovalRequest>.Update(BorrowApprovalRequest item)
        {
            throw new NotImplementedException();
        }
    }
}
