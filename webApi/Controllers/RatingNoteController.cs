using BLL;
using BLL.BllModels;
using BLL.IBll;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingNoteController : Controller
    {
        private IbllRatingNote _rating;
        public RatingNoteController(BlManager bLManager)
        {
            this._rating = bLManager.BlRatingNote;
        }



        [HttpGet("GetRatingNote/{userId}/{itemId}")]
        public async Task<ActionResult<BllRatingNote>> GetPrevRatingNote(int userId, int itemId)
        {
            try
            {
                return await _rating.getRatingNote(userId, itemId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the rating note: " + ex.Message);
            }
        }


        [HttpPut("PutRatingNote")]
        public async Task<ActionResult<bool>> UpdateRatingNote([FromBody] BllRatingNote rating)
        {
            try
            {
                return await _rating.Update(rating);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the rating note: " + ex.Message);
            }
        }


    }
}
