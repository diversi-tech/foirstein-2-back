using DAL.DalService;
using dal.models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    public class SearchLogUnitTest
    {

        [Fact]
        public async Task Create_SearchLog_Exception()
        {
            // Arrange
            var item = new SearchLog(); 
            var mockContext = new Mock<LiberiansDbContext>(); 
            mockContext.Setup(c => c.SaveChanges()).Throws(new Exception("Simulated error")); 
            var searchLogService = new SearchLogService(mockContext.Object); 

            // Act and Assert
            await Assert.ThrowsAsync<Exception>(() => searchLogService.Create(item)); 
        }
    }
}
