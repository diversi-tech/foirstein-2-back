using BLL;
using BLL.BllModels;
using BLL.IBll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IbllItem _ibllItem;

        public ItemController(BlManager blManager)
        {
            _ibllItem = blManager.ibllItem;
        }

        [HttpGet("{searchKey}")]
        public async Task<IEnumerable<BllItem>> ReadByString(string searchKey)
        {
            try
            {
                return await _ibllItem.ReadByString(searchKey);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}