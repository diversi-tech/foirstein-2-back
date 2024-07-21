using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBAPI.Controllers;

namespace TEST
{
    public class TagsUnitTest
    {
        static BlManager blManager = new BlManager();
        static TagController tagController = new TagController(blManager);

        [Fact]
        public async Task TestGetAllTagsById_ReturnsEmptyListForUnknownId()
        {
            var tags = await tagController.GetAllTagsById(-1);
            Assert.Empty(tags);
        }
    }
}
