using BLL;
using BLL.BllModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using static BLL.Exeptions.BorrowRequestExeptions;

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
        [HttpPost]
        [Route("AddBorrowRequest")]
        public async Task<ActionResult<bool>> AddBorrowRequest(BllBorrowRequest borrowRequest)
        {
            try
            {

                bool result = await _blManager.BorrowRequests.Create(borrowRequest);

                if (result)
                {
                    return Ok(true); // HTTP 200 OK if successful
                }
                else
                {
                    return BadRequest("Adding failed"); // HTTP 400 Bad Request if failed

                }

            }
            catch (ItemTakenException ex)
            {
                return BadRequest(ex.Message); // HTTP 400 Bad Request with custom exception message
            }
            catch (MaximumBorrowDurationExceededException ex)
            {
                return BadRequest(ex.Message); // HTTP 400 Bad Request with custom exception message
            }
            catch (InvalidLoanDatesException ex)
            {
                return BadRequest(ex.Message); // HTTP 400 Bad Request with custom exception message
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred"); // HTTP 500 Internal Server Error for other exceptions
            }
        }
    }
}