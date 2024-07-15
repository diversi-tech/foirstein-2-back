using AutoMapper;
using AutoMapper.Internal;
using BL.BLApi;
using BLL.BllModels;
using BLL.IBll;
using dal.models;
using DAL;
using DAL.IDal;
using System.Linq;
namespace BLL.BllService
{
    public class BllBorrowRequestsService : IbllBorrowRequest
    {
        private IMapper mapper;
        private DalManager _dalManager;
        public BllBorrowRequestsService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
                // Add any additional mapping configurations here
            });
            mapper = new Mapper(config);
            _dalManager = new DalManager();
        }
        public BllBorrowRequestsService(IMapper mapper, DalManager dalManager)
        {
            mapper = mapper;
            _dalManager = dalManager;
        }
        public void MapBorrowRequest()
        {
            BllBorrowRequest bllRequest = new BllBorrowRequest
            {
                // Set properties for bllRequest as needed
            };
            BorrowRequest dalRequest = mapper.Map<BorrowRequest>(bllRequest);
            // Use the mapped dalRequest object as needed
        }

        public async Task<bool> Create(BllBorrowRequest item)
        {
            try
            {
                var dalRequest = mapper.Map<BorrowRequest>(item);
                await _dalManager.BorrowRequests.Create(dalRequest);
                // Additional logic after adding the request
                return true; // Return true if successful
            }
            catch (Exception ex)
            {
                return false; // Return false if an exception occurred
            }
        }

        public async Task<bool> deletRequest(int id)
        {
            try
            {
                BorrowRequest borrowRequestToDelete = await _dalManager.BorrowRequests.ReadbyId(id);
                await _dalManager.BorrowRequests.Delete(borrowRequestToDelete);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BllItem>> getAllItemToUser(int userId)
        {
            try
            {
                List<BorrowApprovalRequest> borrowApprovalRequests = await _dalManager.BorrowApprovalRequests.Read(br => br.UserId == userId);
                List<BorrowRequest> borrowRequests = await _dalManager.BorrowRequests.Read(br => br.UserId == userId);

                /*   var itemIds = borrowRequests.Select(br => br.ItemId)
                                               .Concat(borrowApprovalRequests.Select(br => br.ItemId))
                                               .Distinct() .ToList();*/
                /*   var itemIds = borrowApprovalRequests.Select(bar => bar.ItemId).ToList();
                    itemIds.AddRange((IEnumerable<int>)borrowRequests.Select(br => br.ItemId));
    */

                List<int> itemIds = new List<int>();

                foreach (var borrowApprovalRequest in borrowApprovalRequests)
                {
                      itemIds.Add(borrowApprovalRequest.ItemId);
                 
                }

                foreach (var borrowRequest in borrowRequests)
                {
                     itemIds.Add(borrowRequest.ItemId.Value);
               
                }

                // קריאת רשימת הפריטים לפי itemIds
/*                List<Item> items = await _dalManager.Items.Read(i => itemIds.Contains(i.Id));
*/
                List<Item> items = await _dalManager.items.Read(i => itemIds.Contains(i.Id));
                return mapper.Map<List<Item>, List<BllItem>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BllBorrowRequest>> Read(Func<BllBorrowRequest, bool> filter)
        {
            try
            {
                List<BorrowRequest> borrowRequests = await _dalManager.BorrowRequests.Read(br => br.UserId.Equals(filter.Target.ToString()));
                return mapper.Map<List<BorrowRequest>, List<BllBorrowRequest>>(borrowRequests);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<dynamic> GetBorrowRequestsAndApprovals(int userId)
        {
            try
            {
                var borrowApprovalRequests = await _dalManager.BorrowApprovalRequests.Read(br => br.UserId == userId);
                var borrowRequests = await _dalManager.BorrowRequests.Read(br => br.UserId == userId);

                var mappedBorrowApprovalRequests = mapper.Map<List<BorrowApprovalRequest>, List<BllBorrowApprovalRequest>>(borrowApprovalRequests);
                var mappedBorrowRequests = mapper.Map<List<BorrowRequest>, List<BllBorrowRequest>>(borrowRequests);

                var result = new
                {
                    BorrowApprovalRequests = mappedBorrowApprovalRequests,
                    BorrowRequests = mappedBorrowRequests
                };

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BllBorrowRequest>> Read(int userId)
        {
            try
            {
                List<BorrowRequest> borrowRequests = await _dalManager.BorrowRequests.Read(br => br.UserId == userId);
                return mapper.Map<List<BorrowRequest>, List<BllBorrowRequest>>(borrowRequests);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BllBorrowRequest>> ReadAll()
        {
            try
            {
                List<BorrowRequest> borrowRequests = await _dalManager.BorrowRequests.ReadAll();
                return mapper.Map<List<BorrowRequest>, List<BllBorrowRequest>>(borrowRequests);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BllBorrowRequest> ReadbyId(int item)
        {
            try
            {
                BorrowRequest borrowRequest = await _dalManager.BorrowRequests.ReadbyId(item);
                return mapper.Map<BorrowRequest, BllBorrowRequest>(borrowRequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> Update(BllBorrowRequest item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(BllBorrowRequest item)
        {
            throw new NotImplementedException();
        }


    }
}
