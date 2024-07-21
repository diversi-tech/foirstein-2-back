using BLL;
using BLL.BllModels;
using BLL.IBll;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WEBAPI.Controllers;

namespace TEST
{
    public class TagsUnitTest
    {
        private readonly Mock<IbllTag> mockIbllTag;
        private readonly TagController tagController;

        public TagsUnitTest()
        {
            mockIbllTag = new Mock<IbllTag>();
            tagController = new TagController(new BlManager());
            var ibllTagField = typeof(TagController).GetField("ibllTag", BindingFlags.NonPublic | BindingFlags.Instance);
            ibllTagField.SetValue(tagController, mockIbllTag.Object);
        }

        [Fact]
        public async Task TestGetAllTagsById_ReturnsCorrectTags()
        {
            var itemId = 11;
            mockIbllTag.Setup(m => m.ReadAll(itemId)).ReturnsAsync(new List<BllTag>
            {
                new BllTag { Id = 6, Name = "ילדים" },
                new BllTag { Id = 7, Name = "חומרי עזר" },
                new BllTag { Id = 12, Name = "נוער" }
            });
            var tags = await tagController.GetAllTagsById(itemId);
            List<BllTag> expectedTags = new List<BllTag>
            {
                new BllTag { Id = 6, Name = "ילדים" },
                new BllTag { Id = 7, Name = "חומרי עזר" },
                new BllTag { Id = 12, Name = "נוער" }
            };

            Assert.Collection(tags,
                tag =>
                {
                    Assert.Equal(expectedTags[0].Id, tag.Id);
                    Assert.Equal(expectedTags[0].Name, tag.Name);
                },
                tag =>
                {
                    Assert.Equal(expectedTags[1].Id, tag.Id);
                    Assert.Equal(expectedTags[1].Name, tag.Name);
                },
                tag =>
                {
                    Assert.Equal(expectedTags[2].Id, tag.Id);
                    Assert.Equal(expectedTags[2].Name, tag.Name);
                });
        }

        [Fact]
        public async Task TestGetAllTagsById_ReturnsEmptyListForUnknownId()
        {
            var itemId = -1;
            mockIbllTag.Setup(m => m.ReadAll(itemId)).ReturnsAsync(new List<BllTag>());
            var tags = await tagController.GetAllTagsById(itemId);
            Assert.Empty(tags);
        }

        [Fact]
        public async Task TestGetAllTagsById_ReturnsSingleTag()
        {
            var itemId = 7;
            mockIbllTag.Setup(m => m.ReadAll(itemId)).ReturnsAsync(new List<BllTag>
            {
                new BllTag { Id = 7, Name = "חומרי עזר" }
            });
            var tags = await tagController.GetAllTagsById(itemId);
            Assert.Single(tags, tag => tag.Id == 7 && tag.Name == "חומרי עזר");
        }

        [Fact]
        public async Task TestGetAllTagsById_ReturnsMultipleTags()
        {
            var itemId = 8;
            mockIbllTag.Setup(m => m.ReadAll(itemId)).ReturnsAsync(new List<BllTag>
            {
                new BllTag { Id = 6, Name = "ילדים" },
                new BllTag { Id = 7, Name = "חומרי עזר" }
            });
            var tags = await tagController.GetAllTagsById(itemId);
            Assert.Equal(2, tags.Count);
            Assert.Contains(tags, tag => tag.Id == 6 && tag.Name == "ילדים");
            Assert.Contains(tags, tag => tag.Id == 7 && tag.Name == "חומרי עזר");
        }

        [Fact]
        public async Task TestGetAllTagsById_DuplicateTags()
        {
            int itemId = 11;
            var duplicateTags = new List<BllTag>
            {
                new BllTag { Id = 6, Name = "Tag1" },
                new BllTag { Id = 7, Name = "Tag2" },
                new BllTag { Id = 6, Name = "Tag1" } 
            };
            mockIbllTag.Setup(m => m.ReadAll(itemId)).ReturnsAsync(duplicateTags);
            var result = await tagController.GetAllTagsById(itemId);
            var duplicateCheck = result.GroupBy(x => x.Id).Any(g => g.Count() > 1);
            Assert.True(duplicateCheck, "The result contains duplicate tags");
        }
    }
}
