﻿using dal.models;
using DAL.IDal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalService
{
    public class SearchLogService : ISearchLog
    {
        private LiberiansDbContext _context;

        public SearchLogService(LiberiansDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(SearchLog item)
        {
            try
            {
                _context.SearchLogs.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("error on create", ex);
            }
        }

        public Task<bool> Delete(SearchLog item)
        {
            throw new NotImplementedException();
        }

        public Task<List<SearchLog>> Read(Func<SearchLog, bool> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SearchLog>> ReadAll()
        {
            return _context.SearchLogs.ToList();
        }

        public Task<SearchLog> ReadbyId(int item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(SearchLog item)
        {
            throw new NotImplementedException();
        }
    }
}
