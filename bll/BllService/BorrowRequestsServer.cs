using AutoMapper;
using BL.BLApi;
using BLL.BllModels;
using BLL.IBll;
using dal.models;
using DAL;
using DAL.IDal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BllService
{
    internal class BorrowRequestsServer : IBorrowRequests
    {
        private DalManager _dalManager;
        private IMapper mapper;


        public BorrowRequestsServer(DalManager _dalManager)
        {
            this._dalManager = _dalManager;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            mapper = config.CreateMapper();

        }

        public Task<bool> Create(BllBorrowRequest item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(BllBorrowRequest item)
        {
            throw new NotImplementedException();

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

        public async Task<List<BLLItem>> getAllItemToUser(int userId)
        {
            try
            {
                List<BorrowRequest> borrowRequests = await _dalManager.BorrowRequests.Read(br => br.UserId == userId);
                var itemIds = borrowRequests.Select(br => br.ItemId).ToList();
                List<Item> items = await _dalManager.items.Read(i => itemIds.Contains(i.Id));
                return mapper.Map<List<Item>, List<BLLItem>>(items);
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


    }
}
/*
 using AutoMapper;
using BL.BLApi;
using BLL.BllModels;
using BLL.IBll;
using dal.models;
using DAL;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.BllService
{
    internal class BorrowRequestsServer : IBorrowRequests
    {
        private readonly DalManager _dalManager;
        private readonly IMapper _mapper;
        private readonly ILogger<BorrowRequestsServer> _logger;

        public BorrowRequestsServer(DalManager dalManager, IMapper mapper, ILogger<BorrowRequestsServer> logger)
        {
            _dalManager = dalManager ?? throw new ArgumentNullException(nameof(dalManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public  Task<bool> Create(BllBorrowRequest item)
        {
            throw new NotImplementedException();

        }

        public  Task<bool> Delete(BllBorrowRequest item)
        {
            throw new NotImplementedException();

        }

        public async Task<List<BLLItem>> getAllItemToUser(int userId)
        {
            try
            {
                List<BorrowRequest> borrowRequests = await _dalManager.BorrowRequests.Read(br => br.UserId == userId);
                var itemIds = borrowRequests.Select(br => br.ItemId).ToList();
                List<Item> items = await _dalManager.items.Read(i => itemIds.Contains(i.Id));
                return _mapper.Map<List<Item>, List<BLLItem>>(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving items for user {UserId}", userId);
                throw;
            }
        }

        

        public async Task<List<BllBorrowRequest>> Read(Func<BllBorrowRequest, bool> filter)
        {
            try
            {
                List<BorrowRequest> borrowRequests = await _dalManager.BorrowRequests.Read(br => br.UserId.Equals(filter.Target.ToString()));
                return _mapper.Map<List<BorrowRequest>, List<BllBorrowRequest>>(borrowRequests);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while reading borrow requests with custom filter");
                throw;
            }
        }

        public async Task<List<BllBorrowRequest>> Read(int userId)
        {
            try
            {
                List<BorrowRequest> borrowRequests = await _dalManager.BorrowRequests.Read(br => br.UserId == userId);
                return _mapper.Map<List<BorrowRequest>, List<BllBorrowRequest>>(borrowRequests);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while reading borrow requests for user {UserId}", userId);
                throw;
            }
        }

        public async Task<List<BllBorrowRequest>> ReadAll()
        {
            try
            {
                List<BorrowRequest> borrowRequests = await _dalManager.BorrowRequests.ReadAll();
                return _mapper.Map<List<BorrowRequest>, List<BllBorrowRequest>>(borrowRequests);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while reading all borrow requests");
                throw;
            }
        }

      

        public Task<BllBorrowRequest> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        public  Task<bool> Update(BllBorrowRequest item)
        {
            throw new NotImplementedException();

        }
    }
}
*/