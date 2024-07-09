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
    public class BorrowRequestService : IBorrowRequest
    {
        private LiberiansDbContext db;
        public BorrowRequestService(LiberiansDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> Create(BorrowRequest item)
        {
            try
            {
                await db.BorrowRequests.AddAsync(item);
                await db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating loan request: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Delete(BorrowRequest item)
        {
            try
            {
                BorrowRequest item1 = db.BorrowRequests.ToList().Find(t => t.RequestId == item.RequestId);
                db.BorrowRequests.Remove(item1);
                await db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public async Task<List<BorrowRequest>> Read(Func<BorrowRequest, bool> filter)
        {
            try
            {
                return db.BorrowRequests.Where(filter).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<BorrowRequest>> ReadAll() => db.BorrowRequests.ToList();

        public async Task<BorrowRequest> ReadbyId(int item)
        {
            try
            {
                BorrowRequest? itemReqest = db.BorrowRequests.ToList().Find(t => t.RequestId == item);

                return itemReqest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> Update(BorrowRequest item)
        {
            throw new NotImplementedException();
        }
    }
}