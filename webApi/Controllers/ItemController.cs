﻿using BLL;
using BLL.BllModels;
using BLL.IBll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

﻿
using BLL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IbllItem _ibllItem;

        public ItemController(BlManager blManager)
        {
            _ibllItem = blManager.bllItem;
        }

        [HttpGet("ReadByString/{searchKey}")]
        public async Task<IEnumerable<BllItem>> ReadByString(string searchKey)
        {
            try
            {
                return await _ibllItem.ReadByString(searchKey);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching items by searchKey.", ex);
            }

        }

        [HttpGet("ReadByCategory/{category}")]
        public async Task<IEnumerable<BllItem>> ReadByCategory(string category)
        {
            try
            {
                var result = await _ibllItem.ReadByCategory(category);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching items by category.", ex);
            }
        }

        [HttpGet("ReadTheRecommended")]
        public async Task<IEnumerable<BllItem>> ReadTheRecommended()
        {
            try
            {
                var result = await _ibllItem.ReadTheRecommended();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while find the recommended items.", ex);
            }
        }

        [HttpGet("ReadByTag/{tagId}")]
        public async Task<IEnumerable<BllItem>> ReadByTag(int tagId)
        {
            try
            {
                var result = await _ibllItem.ReadByTag(tagId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetch items by tag", ex);
            }
        }

        [HttpPost("ReadByAttributes")]
        public async Task<IEnumerable<BllItem>> ReadByAttributes([FromBody] BllItem searchItem)
        {
            try
            {
                return await _ibllItem.ReadByAttributes(searchItem);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}


    