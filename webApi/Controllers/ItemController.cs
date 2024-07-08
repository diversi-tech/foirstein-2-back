
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
