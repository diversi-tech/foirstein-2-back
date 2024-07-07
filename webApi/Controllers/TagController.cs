using BLL.BllModels;
using BLL.IBll;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private IbllTag ibllTag;
        public TagController(BlManager blManager)
        {
            this.ibllTag = blManager.bllTag;
        }

        [HttpGet("GetAllTagsByItemId")]
        public async Task<List<BllTag>> GetAllTagsById(int itemId)
        {
            try
            {
                return await ibllTag.ReadAll(itemId);
            }
            catch
            {
                return null;
            }
        }

    }
}
