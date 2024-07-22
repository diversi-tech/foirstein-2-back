using AutoMapper;
using BLL.BllModels;
using BLL.IBll;
using dal.models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BllService
{
    public class BllSearchLogService : IbllSearchLog
    {
        private DalManager _dalManager;
        private IMapper _mapper;
        public BllSearchLogService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            _mapper = new Mapper(config);
            _dalManager = new DalManager();
        }

        public BllSearchLogService(IMapper mapper, DalManager dalManager)
        {
            _mapper = mapper;
            _dalManager = dalManager;
        }
        public async Task<bool> Create(BllSearchLog item)
        {
            try
            {
                var searchLog = _mapper.Map<SearchLog>(item);

                bool success = await _dalManager.SearchLogs.Create(searchLog);

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create", ex);
            }
        }

        public Task<bool> Delete(BllSearchLog item)
        {
            throw new NotImplementedException();
        }

        public Task<List<BllSearchLog>> Read(Func<BllSearchLog, bool> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BllSearchLog>> ReadAll()
        {
            try
            {
                var dalSearchLog = await _dalManager.SearchLogs.ReadAll();

                var bllSearchLog = dalSearchLog.Select(_mapper.Map<BllSearchLog>).ToList();

                return bllSearchLog;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to read all", ex);
            }
        }

        public Task<BllSearchLog> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(BllSearchLog item)
        {
            throw new NotImplementedException();
        }
    }
}
