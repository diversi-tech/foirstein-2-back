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
        private LiberiansDbContext db;
        public BorrowApprovalRequestService(LiberiansDbContext db)
        {
            this.db = db;
        }
        public Task<bool> Create(BorrowApprovalRequest item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(BorrowApprovalRequest item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BorrowApprovalRequest>> Read(Func<BorrowApprovalRequest, bool> filter)
        {
            try
            {
                return db.BorrowApprovalRequests.Where(filter).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BorrowApprovalRequest>> ReadAll() => db.BorrowApprovalRequests.ToList();

        public async Task<BorrowApprovalRequest> ReadbyId(int item)
        {
            try
            {
                BorrowApprovalRequest? itemReqest = db.BorrowApprovalRequests.ToList().Find(t => t.RequestId == item);

                return itemReqest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public Task<bool> Update(BorrowApprovalRequest item)
        {
            throw new NotImplementedException();
        }
    }
}
