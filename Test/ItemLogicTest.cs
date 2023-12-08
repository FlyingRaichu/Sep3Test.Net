using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DaoInterfaces;
using Application.Logic;
using Domain.DTOs;
using Domain.DTOs.Item;
using Moq;
using NUnit.Framework;

namespace Test;

    [TestFixture]
    public class ItemLogicTests
    {
        private Mock<IItemDao> mockItemDao;
        private ItemLogic itemLogic;

        [SetUp]
        public void SetUp()
        {
            mockItemDao = new Mock<IItemDao>();
            itemLogic = new ItemLogic(mockItemDao.Object);
        }

        [Test]
        public async Task GetAsync_WithSearchParameters_ReturnsFilteredItems()
        {
            // Arrange
            var searchParameters = new SearchItemParametersDto("Hello Yarn", null, null, null, null, null, null);

            var expectedFilteredItems = new List<Item>
            {
               new Item()
               {
                   Id = 1,
                   Title = "Hello Yarn",
                   Description = "this is a test yarn that speaks",
                   Price = 1.4,
                   Manufacturer = "monsters inc.",
                   Stock = 10,
                   Tags = { 1, 2, 3 },
                   DiscountPercentage = 10
               }
            };

            mockItemDao.Setup(dao => dao.GetAsync(searchParameters)).ReturnsAsync(expectedFilteredItems);

            // Act
            var filteredItems = await itemLogic.GetAsync(searchParameters);

            // Assert
            Assert.NotNull(filteredItems);
            Assert.AreEqual(expectedFilteredItems.Count, filteredItems.Count());
            // Add more assertions as needed
        }

        [Test]
        public async Task GetFavItemsByUserAsync_WithUserId_ReturnsFavoriteItems()
        {
            // Arrange
            var userId = 1;
            var expectedFavoriteItems = new List<Item>
            {
                new Item()
                {
                    Id = 1,
                    Title = "Hello Yarn",
                    Description = "this is a test yarn that speaks",
                    Price = 1.4,
                    Manufacturer = "monsters inc.",
                    Stock = 10,
                    Tags = { 1, 2, 3 },
                    DiscountPercentage = 10
                }
            };

            mockItemDao.Setup(dao => dao.GetFavItemsByUserAsync(userId)).ReturnsAsync(expectedFavoriteItems);

            // Act
            var favoriteItems = await itemLogic.GetFavItemsByUserAsync(userId);

            // Assert
            Assert.NotNull(favoriteItems);
            Assert.AreEqual(expectedFavoriteItems.Count, favoriteItems.Count());
            // Add more assertions as needed
        }

        [Test]
        public async Task CreateAsync_ValidItem_ReturnsCreatedItem()
        {
            // Arrange
            var itemCreationDto = new ItemCreationDto("title", "description", 1.5, "idk man", 10,
                new List<int>() { 1, 2, 3 }, 1.5);

            mockItemDao.Setup(dao => dao.CreateAsync(It.IsAny<Item>())).ReturnsAsync(new Item());

            // Act
            var createdItem = await itemLogic.CreateAsync(itemCreationDto);

            // Assert
            Assert.NotNull(createdItem);
            // Add more assertions as needed
        }

        [Test]
        public async Task CreateAsync_InvalidItem_ThrowsException()
        {
            // Arrange
            var invalidItemCreationDto = new ItemCreationDto("title", "description", -1, "idk man", -10,
                null, 1.5);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await itemLogic.CreateAsync(invalidItemCreationDto));
        }

        [Test]
        public async Task UpdateAsync_ExistingItem_UpdatesItem()
        {
            // Arrange
            var itemUpdateDto = new ItemUpdateDto(1)
            {
                Title = "what's up beaches",
                Manufacturer = "this is a real company"
            };

            var existingItem = new Item
            {
                Id = 1,
                Title = "why am i here",
                Description = "this is the highest quality of yarn in the exisance",
                Price = 1.5,
                Manufacturer = "inc inc.",
                Stock = 10,
                Tags = { 2,4,5, },
                DiscountPercentage = 1.4
            };

            mockItemDao.Setup(dao => dao.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(existingItem);
            mockItemDao.Setup(dao => dao.UpdateAsync(It.IsAny<Item>()));

            // Act
            await itemLogic.UpdateAsync(itemUpdateDto);

            // Assert
            mockItemDao.Verify(dao => dao.UpdateAsync(It.IsAny<Item>()), Times.Once);
            // Add more assertions as needed
        }

        [Test]
        public async Task UpdateAsync_NonExistingItem_ThrowsException()
        {
            // Arrange
            var itemUpdateDto = new ItemUpdateDto(-1)
            {
                Title = "what's up beaches",
                Manufacturer = "this is a real company"
            };

            mockItemDao.Setup(dao => dao.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Item)null);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await itemLogic.UpdateAsync(itemUpdateDto));
        }

        [Test]
        public async Task DeleteAsync_ExistingItem_DeletesItem()
        {
            // Arrange
            var itemId = 1;
            mockItemDao.Setup(dao => dao.DeleteAsync(itemId));

            // Act
            await itemLogic.DeleteAsync(itemId);

            // Assert
            mockItemDao.Verify(dao => dao.DeleteAsync(itemId), Times.Once);
        }

        [Test]
        public async Task DeleteAsync_NonExistingItem_ThrowsException()
        {
            // Arrange
            var nonExistingItemId = 999;
            mockItemDao.Setup(dao => dao.DeleteAsync(nonExistingItemId)).ThrowsAsync(new Exception("Item not found"));

            // Act & Assert
            var exception = Assert.ThrowsAsync<Exception>(async () => await itemLogic.DeleteAsync(nonExistingItemId));
            Assert.AreEqual("Item not found", exception.Message);
        }

        [Test]
        public async Task GetByIdAsync_ExistingItem_ReturnsItem()
        {
            // Arrange
            var existingItemId = 1;
            mockItemDao.Setup(dao => dao.GetByIdAsync(existingItemId)).ReturnsAsync(new Item());

            // Act
            var item = await itemLogic.GetByIdAsync(existingItemId);

            // Assert
            Assert.NotNull(item);
            // Add more assertions as needed
        }

        [Test]
        public async Task GetByIdAsync_NonExistingItem_ThrowsException()
        {
            // Arrange
            var nonExistingItemId = 999;
            mockItemDao.Setup(dao => dao.GetByIdAsync(nonExistingItemId)).ReturnsAsync((Item)null);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await itemLogic.GetByIdAsync(nonExistingItemId));
        }

        // Add more tests for other methods in the ItemLogic class
}
