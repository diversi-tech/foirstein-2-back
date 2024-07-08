using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowRequestController : ControllerBase
    {
        private readonly BlManager _blManager;

        public BorrowRequestController(BlManager blManager)
        {
            _blManager = blManager;
        }

        [HttpGet("borrow-requests")]
        public async Task<IActionResult> GetBorrowRequests()
        {
            try
            {
                var borrowRequests = await _blManager.BorrowRequests.ReadAll();
                return Ok(borrowRequests);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("borrow-requests/{Id}")]
        public async Task<IActionResult> GetBorrowRequestsForStudent(int Id)
        {
            try
            {
                var borrowRequests = await _blManager.BorrowRequests.Read(Id);
                return Ok(borrowRequests);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("getAllItemToUser/{Id}")]
        public async Task<IActionResult> GetAllItemToUser(int Id)
        {
            try
            {
                var borrowRequests = await _blManager.BorrowRequests.getAllItemToUser(Id);
                return Ok(borrowRequests);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {


                bool deleted = await _blManager.BorrowRequests.deletRequest(id);

                if (deleted)
                {
                    return NoContent();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete item");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error occurred: {ex.Message}");
            }
        }
    }
}
