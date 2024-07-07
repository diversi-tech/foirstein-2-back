using AutoMapper;
using BLL.BllModels;
using BLL.IBll;
using dal.models;
using DAL;
namespace BLL.BllService
{
    public class BllBorrowRequestsService : IbllBorrowRequest
    {
        private IMapper _mapper;
        private DalManager _dalManager;
        public BllBorrowRequestsService()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MapperProfile>();
                // Add any additional mapping configurations here
            });
            _mapper = new Mapper(config);
            _dalManager = new DalManager();
        }
        public BllBorrowRequestsService(IMapper mapper, DalManager dalManager)
        {
            _mapper = mapper;
            _dalManager = dalManager;
        }
        public void MapBorrowRequest()
        {
            BllBorrowRequest bllRequest = new BllBorrowRequest
            {
                // Set properties for bllRequest as needed
            };
            BorrowRequest dalRequest = _mapper.Map<BorrowRequest>(bllRequest);
            // Use the mapped dalRequest object as needed
        }
        public async Task<bool> Create(BllBorrowRequest item)
        {
            try
            {
                var dalRequest = _mapper.Map<BorrowRequest>(item);
                await _dalManager.BorrowRequests.Create(dalRequest);
                // Additional logic after adding the request
                return true; // Return true if successful
            }
            catch (Exception ex)
            {
                return false; // Return false if an exception occurred
            }
        }
        public Task<bool> Delete(BllBorrowRequest item)
        {
            throw new NotImplementedException();
        }
        public List<BllBorrowRequest> Read(Func<BllBorrowRequest, bool> filter)
        {
            throw new NotImplementedException();
        }
        public Task<BllBorrowRequest> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }
        public Task<List<BllBorrowRequest>> ReadAll()
        {
            throw new NotImplementedException();
        }
        public Task<bool> Update(BllBorrowRequest item)
        {
            throw new NotImplementedException();
        }
        // Implement other interface methods
    }
}
