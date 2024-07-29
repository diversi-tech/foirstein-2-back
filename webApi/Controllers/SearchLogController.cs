using BLL;
using BLL.BllModels;
using BLL.IBll;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchLogController : Controller
    {
        private IbllSearchLog _ibllSearchLog;

        public SearchLogController(BlManager blManager)
        {
            _ibllSearchLog = blManager.bllSearchLog;
        }

        [HttpPost("create")]
        public async Task<bool> Create(BllSearchLog item)
        {
            try
            {
                Console.WriteLine(item.ToString());
                return await _ibllSearchLog.Create(item);
            }
            catch (Exception ex)
            {
                throw new Exception("error in create", ex);
            }
        }

        [HttpGet("ReadAll")]
        public async Task<List<BllSearchLog>> ReadAll()
        {
            try
            {
                return await _ibllSearchLog.ReadAll();
            }
            catch (Exception ex)
            {
                throw new Exception("error in read all", ex);
            }
        }
    }
}
