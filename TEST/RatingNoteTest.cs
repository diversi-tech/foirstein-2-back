using BLL;
using BLL.BllModels;
using BLL.IBll;
using Moq;
using System.Reflection;
using webApi.Controllers;
using Xunit.Abstractions;

namespace TEST
{
    public class RatingNoteTest
    {
        private readonly Mock<IbllRatingNote> mockIbllRatingNote;
        private readonly RatingNoteController ratingNoteController;
        public RatingNoteTest(ITestOutputHelper output)
        {
            mockIbllRatingNote = new Mock<IbllRatingNote>();
            ratingNoteController = new RatingNoteController(new BlManager());
            var ibllRating = typeof(RatingNoteController).GetField("_rating", BindingFlags.NonPublic | BindingFlags.Instance);
            ibllRating.SetValue(ratingNoteController, mockIbllRatingNote.Object);


        }

        [Fact]
        public async Task TestGetRatingNote_ReturnsCorrectRatingNote()
        {
            int userId = 1;
            int itemId = 1;
            BllRatingNote expectedRatingNote = new BllRatingNote(1, userId, itemId, "Test Note", 5,true);
            mockIbllRatingNote.Setup(m => m.getRatingNote(userId, itemId)).ReturnsAsync(expectedRatingNote);

            var result =( await ratingNoteController.GetPrevRatingNote(userId, itemId)).Value;

            Assert.Equal(expectedRatingNote.RatingNoteId, result.RatingNoteId);
            Assert.Equal(expectedRatingNote.UserId, result.UserId);
            Assert.Equal(expectedRatingNote.ItemId, result.ItemId);
            Assert.Equal(expectedRatingNote.Note, result.Note);
            Assert.Equal(expectedRatingNote.Rating, result.Rating);
        }

        [Fact]
        public async Task TestGetRatingNote_RatingNoteNotFound()
        {
            var result = await ratingNoteController.GetPrevRatingNote(1, 11);

            Assert.Null(result.Value);
        }



        [Fact]
        public async Task TestUpdateRatingNote_SuccessEditNewRatingNote()
        {
            int userId = 1;
            int itemId = 1;
            BllRatingNote ratingNote = new BllRatingNote(0, userId, itemId, "Test Note", 5, true);
            mockIbllRatingNote.Setup(m => m.Update(ratingNote)).ReturnsAsync(true);

            var result = await ratingNoteController.UpdateRatingNote(ratingNote);
            var success = Assert.IsType<bool>(result.Value);

            Assert.True(success);

            mockIbllRatingNote.Verify(m => m.Update(ratingNote), Times.Once);
        }

    }
}