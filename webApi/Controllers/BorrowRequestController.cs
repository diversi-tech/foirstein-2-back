using BLL;
using BLL.IBll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowRequestController : ControllerBase
    {


        private IbllBorrowRequest _bosses;
        public BorrowRequestController( BlManager _blManager)
        {
            
        }
    }
}
