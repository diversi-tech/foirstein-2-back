using DAL.DalService;
using dal.models;
using DAL;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BllService;
using WEBAPI.Controllers;
using AutoMapper;
using BLL.BllModels;
using BLL;
using Microsoft.EntityFrameworkCore;

namespace TEST
{
    public class ItemUnitTest
    {

        [Fact]
        public async Task TestReadByString()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>();
            var mockDalManager = new Mock<DalManager>();
            var mockBlManager = new Mock<BlManager>();
            var mockBllItem = new Mock<BllItem>();

            var items = new List<Item>
            {
                new Item { Title = "Sample Title", Description = "Sample Description", Category = "Sample Category", Author = "Sample Author" },
            };

            var mockContext = new Mock<LiberiansDbContext>();
            var mockDbSet = new Mock<DbSet<Item>>();

            mockDbSet.As<IQueryable<Item>>().Setup(m => m.Provider).Returns(items.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.Expression).Returns(items.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.ElementType).Returns(items.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.GetEnumerator()).Returns(items.AsQueryable().GetEnumerator());

            mockContext.Setup(c => c.Items).Returns(mockDbSet.Object);

            var dalService = new ItemService(mockContext.Object);
            var bllService = new BllItemService(mockMapper.Object, mockDalManager.Object);
            var controller = new ItemController(mockBlManager.Object);

            // Act
            var result = await controller.ReadByString("א");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(items.Count, result.Count());
            // Add more assertions based on your specific requirements
        }

        [Fact]
        public async Task ReadByString_ReturnsItemsMatchingSearchKey()
        {
            // Arrange
            var searchKey = "Sample";
            var items = new List<Item>
    {
        new Item { Id = 1, Title = "Sample Item", Description = "Description Sample", Category = "Category A", Author = "Sample Author" },
        new Item { Id = 2, Title = "Another Item", Description = "Another Description", Category = "Category B", Author = "Another Author" }
    };

            var mockContext = new Mock<LiberiansDbContext>();
            var mockDbSet = new Mock<DbSet<Item>>();

            mockDbSet.As<IQueryable<Item>>().Setup(m => m.Provider).Returns(items.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.Expression).Returns(items.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.ElementType).Returns(items.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.GetEnumerator()).Returns(items.AsQueryable().GetEnumerator());

            mockContext.Setup(c => c.Items).Returns(mockDbSet.Object);

            var itemService = new ItemService(mockContext.Object);

            // Act
            var result = await itemService.ReadByString(searchKey);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result); // Assuming only one item matches the search key based on the provided data
                                   // Add more specific assertions if needed
        }


        [Fact]
        public async Task ReadByTag_ReturnsItemsWithMatchingTagId()
        {
            // Arrange
            int tagId = 1;
            var mockContext = new Mock<LiberiansDbContext>();
            var mockDbSet = new Mock<DbSet<Item>>();

            var items = new List<Item>
            {
                new Item { Id = 1, Title = "Item 1" },
                new Item { Id = 2, Title = "Item 2" }
            };

            var itemTags = new List<ItemTag>
            {
                new ItemTag { ItemId = 1, TagId = 1 },
                new ItemTag { ItemId = 2, TagId = 2 }
            };

            mockDbSet.As<IQueryable<Item>>().Setup(m => m.Provider).Returns(items.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.Expression).Returns(items.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.ElementType).Returns(items.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.GetEnumerator()).Returns(items.AsQueryable().GetEnumerator());

            mockContext.Setup(c => c.Items).Returns(mockDbSet.Object);

            var mockItemTagsDbSet = new Mock<DbSet<ItemTag>>();
            mockItemTagsDbSet.As<IQueryable<ItemTag>>().Setup(m => m.Provider).Returns(itemTags.AsQueryable().Provider);
            mockItemTagsDbSet.As<IQueryable<ItemTag>>().Setup(m => m.Expression).Returns(itemTags.AsQueryable().Expression);
            mockItemTagsDbSet.As<IQueryable<ItemTag>>().Setup(m => m.ElementType).Returns(itemTags.AsQueryable().ElementType);
            mockItemTagsDbSet.As<IQueryable<ItemTag>>().Setup(m => m.GetEnumerator()).Returns(itemTags.AsQueryable().GetEnumerator());

            mockContext.Setup(c => c.ItemTags).Returns(mockItemTagsDbSet.Object);
            var itemService = new ItemService(mockContext.Object);

            // Act
            var result = await itemService.ReadByTag(tagId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Count());
        }

        [Fact]
        public async Task ReadByAttributes_ReturnsMatchingItems()
        {
            // Arrange
            var searchItem = new Item
            {
                Title = "Sample Title",
                Author = "Sample Author",
                Description = "Sample Description",
                Category = "Sample Category",
                CreatedAt = default(DateTime) // Assuming default DateTime value
            };

            var items = new List<Item>
    {
        new Item { Title = "Sample Title", Author = "Sample Author", Description = "Sample Description", Category = "Sample Category", CreatedAt = default(DateTime) },
        new Item { Title = "Another Title", Author = "Another Author", Description = "Another Description", Category = "Another Category", CreatedAt = DateTime.Now }
    };

            var mockContext = new Mock<LiberiansDbContext>();
            var mockDbSet = new Mock<DbSet<Item>>();

            mockDbSet.As<IQueryable<Item>>().Setup(m => m.Provider).Returns(items.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.Expression).Returns(items.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.ElementType).Returns(items.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.GetEnumerator()).Returns(items.AsQueryable().GetEnumerator());

            mockContext.Setup(c => c.Items).Returns(mockDbSet.Object);

            var itemService = new ItemService(mockContext.Object);

            // Act
            var result = await itemService.ReadByAttributes(searchItem);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result); // Assuming only one item matches the search criteria based on the provided searchItem
                                   // Add more specific assertions if needed
        }

        [Fact]
        public async Task ReadByAttributes_ReturnsAllItemsWhenSearchItemIsEmpty()
        {
            // Arrange
            var searchItem = new Item(); // Empty search criteria

            var items = new List<Item>
    {
        new Item { Title = "Sample Title", Author = "Sample Author", Description = "Sample Description", Category = "Sample Category", CreatedAt = default(DateTime) },
        new Item { Title = "Another Title", Author = "Another Author", Description = "Another Description", Category = "Another Category", CreatedAt = DateTime.Now }
    };

            var mockContext = new Mock<LiberiansDbContext>();
            var mockDbSet = new Mock<DbSet<Item>>();

            mockDbSet.As<IQueryable<Item>>().Setup(m => m.Provider).Returns(items.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.Expression).Returns(items.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.ElementType).Returns(items.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.GetEnumerator()).Returns(items.AsQueryable().GetEnumerator());

            mockContext.Setup(c => c.Items).Returns(mockDbSet.Object);

            var itemService = new ItemService(mockContext.Object);

            // Act
            var result = await itemService.ReadByAttributes(searchItem);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(items.Count, result.Count()); // All items should be returned when search criteria are empty
                                                       // Add more specific assertions if needed
        }

        [Fact]
        public async Task ReadAll_ReturnsAllItems()
        {
            // Arrange
            var items = new List<Item>
    {
        new Item { Id = 1, Title = "Item 1", Category = "Category A" },
        new Item { Id = 2, Title = "Item 2", Category = "Category B" }
    };

            var mockContext = new Mock<LiberiansDbContext>();
            var mockDbSet = new Mock<DbSet<Item>>();

            mockDbSet.As<IQueryable<Item>>().Setup(m => m.Provider).Returns(items.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.Expression).Returns(items.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.ElementType).Returns(items.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.GetEnumerator()).Returns(items.AsQueryable().GetEnumerator());

            mockContext.Setup(c => c.Items).Returns(mockDbSet.Object);

            var itemService = new ItemService(mockContext.Object);

            // Act
            var result = await itemService.ReadAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(items.Count, result.Count); // Ensure all items are returned
                                                     // Add more specific assertions if needed
        }

        [Fact]
        public async Task ReadByCategory_ReturnsItemsByCategory()
        {
            // Arrange
            var category = "Category A";
            var items = new List<Item>
    {
        new Item { Id = 1, Title = "Item 1", Category = "Category A" },
        new Item { Id = 2, Title = "Item 2", Category = "Category A" }
    };

            var mockContext = new Mock<LiberiansDbContext>();
            var mockDbSet = new Mock<DbSet<Item>>();

            mockDbSet.As<IQueryable<Item>>().Setup(m => m.Provider).Returns(items.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.Expression).Returns(items.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.ElementType).Returns(items.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Item>>().Setup(m => m.GetEnumerator()).Returns(items.AsQueryable().GetEnumerator());

            mockContext.Setup(c => c.Items).Returns(mockDbSet.Object);

            var itemService = new ItemService(mockContext.Object);

            // Act
            var result = await itemService.ReadByCategory(category);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count()); // Assuming both items have the specified category
                                             // Add more specific assertions if needed
        }

    }
}