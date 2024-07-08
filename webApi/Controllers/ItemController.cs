<<<<<<< HEAD
﻿using BLL;
using BLL.BllModels;
using BLL.IBll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
=======
﻿
using BLL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
>>>>>>> 75dbee4dcd34de6bb03d90723fe1c7e093864762

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
<<<<<<< HEAD
        private IbllItem _ibllItem;

        public ItemController(BlManager blManager)
        {
            _ibllItem = blManager.bllItem;
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
=======


        private readonly BlManager _blManager;
        public ItemController(BlManager blManager)
        {
            _blManager = blManager;

        }

      
        [HttpGet("Item/{Id}")]
        public IActionResult GetItem(int Id)
        {
            var item = _blManager.Items.ReadbyId(Id);
            return Ok(item.Result);
        }
    }
}
>>>>>>> 75dbee4dcd34de6bb03d90723fe1c7e093864762
