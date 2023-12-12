using Application.DaoInterfaces;
using Application.Logic;
using Domain.DTOs.Order;
using Domain.DTOs.OrderItem;
using Moq;

namespace Test;

public class OrderLogicTest
{
        private Mock<IOrderDao> mockOrderDao;
        private OrderLogic orderLogic;

        [SetUp]
        public void SetUp()
        {
            mockOrderDao = new Mock<IOrderDao>();
            orderLogic = new OrderLogic(mockOrderDao.Object);
        }

        [Test]
        public async Task CreateAsync_ValidOrder_ReturnsCreatedOrder()
        {
            // Arrange
            var orderCreationDto = new OrderCreationDto
            {
                OrderFullName = "John Doe",
                PostCode = 8700,
                Address = "Address 1",
                City = "Horsens",
                PhoneNumber = 12345678,
                Status = "in progress",
                Date = "2023-12-12",
                OrderItems = new List<OrderItemCreationDto>(),
                UserId = 1,
            };

            mockOrderDao.Setup(dao => dao.CreateAsync(It.IsAny<Order>())).ReturnsAsync(new Order());

            // Act
            var createdOrder = await orderLogic.CreateAsync(orderCreationDto);

            // Assert
            Assert.NotNull(createdOrder);
            // Add more assertions as needed
        }

        [Test]
        public async Task CreateAsync_InvalidOrder_ThrowsException()
        {
            // Arrange
            var orderCreationDto = new OrderCreationDto
            {
                OrderFullName = "John Doe",
                PostCode = 87001,
                Address = "Address 1",
                City = "Dabu-di",
                PhoneNumber = 4512345678,
                Status = "in progress",
                Date = "2005-12-123",
                OrderItems = new List<OrderItemCreationDto>() {},
                UserId = 1,
            };

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await orderLogic.CreateAsync(orderCreationDto));
        }

        // Add more tests for other methods in the OrderLogic class

        [Test]
        public async Task GetByIdAsync_ExistingOrder_ReturnsOrder()
        {
            // Arrange
            var existingOrderId = 1;
            mockOrderDao.Setup(dao => dao.GetByIdAsync(existingOrderId)).ReturnsAsync(new Order());

            // Act
            var order = await orderLogic.GetByIdAsync(existingOrderId);

            // Assert
            Assert.NotNull(order);
            // Add more assertions as needed
        }

        [Test]
        public async Task GetByIdAsync_NonExistingOrder_ThrowsException()
        {
            // Arrange
            var nonExistingOrderId = 999;
            mockOrderDao.Setup(dao => dao.GetByIdAsync(nonExistingOrderId)).ReturnsAsync((Order)null);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await orderLogic.GetByIdAsync(nonExistingOrderId));
        }
        
         [Test]
        public async Task UpdateAsync_ExistingOrder_UpdatesOrder()
        {
            // Arrange
            var orderUpdateDto = new OrderUpdateDto
            {
                OrderFullName = "John Doe Jr",
                PostCode = 9012,
                Address = "Address 2",
                City = "Horsens",
                PhoneNumber = 4512345678,
                Status = "in progress",
                Date = "2023-12-08",
                OrderItems = {},
            };

            var existingOrder = new Order
            {
                Id = 1,
                OrderFullName = "John Doe",
                PostCode = 8700,
                Address = "Address 1",
                City = "Horsens",
                PhoneNumber = 4512345678,
                Status = "in progress",
                Date = "2023-12-08",
                Items = {},
                UserId = 1
            };

            mockOrderDao.Setup(dao => dao.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(existingOrder);
            mockOrderDao.Setup(dao => dao.UpdateAsync(It.IsAny<Order>()));

            // Act
            await orderLogic.UpdateAsync(orderUpdateDto);
        }

        [Test]
        public async Task UpdateAsync_NonExistingOrder_ThrowsException()
        {
            // Arrange
            var orderUpdateDto = new OrderUpdateDto
            {
                OrderFullName = "John Doe Jr",
                PostCode = 9012,
                Address = "Address 2",
                City = "Horsens",
                PhoneNumber = 4512345678,
                Status = "in progress",
                Date = "2023-12-08",
                OrderItems = {},
            };

            mockOrderDao.Setup(dao => dao.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Order)null);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await orderLogic.UpdateAsync(orderUpdateDto));
        }

        [Test]
        public async Task GetAllByUserIdAsync_UserHasOrders_ReturnsOrders()
        {
            // Arrange
            var userId = 1;
            var orders = new List<Order>
            {
               new Order()
               {
                   Id = 1,
                   OrderFullName = "John Doe",
                   PostCode = 8700,
                   Address = "Address 1",
                   City = "Horsens",
                   PhoneNumber = 4512345678,
                   Status = "in progress",
                   Date = "2023-12-08",
                   Items = {},
                   UserId = userId
               },
               new Order()
               {
                   Id = 2,
                   OrderFullName = "John Doe Jr",
                   PostCode = 8700,
                   Address = "Address 3",
                   City = "Horsens",
                   PhoneNumber = 4512345678,
                   Status = "in progress",
                   Date = "2023-12-08",
                   Items = {},
                   UserId = userId
               },
               new Order()
               {
                   Id = 3,
                   OrderFullName = "John Doe",
                   PostCode = 8700,
                   Address = "Address 1",
                   City = "Horsens",
                   PhoneNumber = 4512345678,
                   Status = "in progress",
                   Date = "2023-12-08",
                   Items = {},
                   UserId = userId
               }
            };

            mockOrderDao.Setup(dao => dao.GetAllByUserIdAsync(userId)).ReturnsAsync(orders);

            // Act
            var userOrders = await orderLogic.GetAllByUserIdAsync(userId);

            // Assert
            Assert.NotNull(userOrders);
            Assert.IsInstanceOf<IEnumerable<Order>>(userOrders);
            Assert.AreEqual(orders.Count, userOrders.Count());
            // Add more assertions as needed
        }

        [Test]
        public async Task GetAllByUserIdAsync_UserHasNoOrders_ThrowsException()
        {
            // Arrange
            var userId = 1;

            mockOrderDao.Setup(dao => dao.GetAllByUserIdAsync(userId)).ReturnsAsync((List<Order>)null);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await orderLogic.GetAllByUserIdAsync(userId));
        }

        [Test]
        public async Task AddItemToOrder_ValidOrderItem_ReturnsCreatedOrderItem()
        {
            // Arrange
            var orderItemCreationDto = new OrderItemCreationDto(1, 1, 10);

            mockOrderDao.Setup(dao => dao.AddItemToOrder(It.IsAny<OrderItem>())).ReturnsAsync(new OrderItem());

            // Act
            var createdOrderItem = await orderLogic.AddItemToOrder(orderItemCreationDto);

            // Assert
            Assert.NotNull(createdOrderItem);
            // Add more assertions as needed
        }

        [Test]
        public async Task UpdateItemInOrder_ExistingOrderItem_UpdatesOrderItem()
        {
            // Arrange
            var orderItemUpdateDto = new OrderItemUpdateDto(1, 1)
            {
                Quantity = 5
            };
            
            var existingOrder = new Order
            {
                Id = 1,
                OrderFullName = "John Doe",
                PostCode = 8700,
                Address = "Address 1",
                City = "Horsens",
                PhoneNumber = 4512345678,
                Status = "in progress",
                Date = "2023-12-08",
                Items = {new OrderItem
                {
                    Id = 1,
                    ItemId = 1,
                    OrderId = 1,
                    Quantity = 3
                }
                    
                },
                UserId = 1
            };
            
            mockOrderDao.Setup(dao => dao.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(existingOrder);
            mockOrderDao.Setup(dao => dao.UpdateItemInOrder(It.IsAny<OrderItem>()));

            // Act
            await orderLogic.UpdateItemInOrder(orderItemUpdateDto);

            // Assert
            // Add assertions as needed
        }

        [Test]
        public async Task UpdateItemInOrder_NonExistingOrderItem_ThrowsException()
        {
            // Arrange
            var orderItemUpdateDto = new OrderItemUpdateDto(-1, 1)
            {
                Quantity = 4
            };

            var existingOrder = new Order
            {
                Id = 1,
                OrderFullName = "John Doe",
                PostCode = 8700,
                Address = "Address 1",
                City = "Horsens",
                PhoneNumber = 4512345678,
                Status = "in progress",
                Date = "2023-12-08",
                Items = {new OrderItem()
                {
                    Id = 1,
                    ItemId = 1,
                    OrderId = 1,
                    Quantity = 3
                }},
                UserId = 1
            };

            mockOrderDao.Setup(dao => dao.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(existingOrder);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await orderLogic.UpdateItemInOrder(orderItemUpdateDto));
        }

        [Test]
        public async Task DeleteItemFromOrder_ValidOrderItem_DeletesOrderItem()
        {
            // Arrange
            var orderItem = new OrderItem
            {
                Id = 1,
                ItemId = 1,
                OrderId = 1,
                Quantity = 3
            };

            mockOrderDao.Setup(dao => dao.DeleteItemFromOrder(It.IsAny<OrderItem>()));

            // Act
            await orderLogic.DeleteItemFromOrder(orderItem);

            // Assert
            // Add assertions as needed
        }

        [Test]
        public async Task DeleteAsync_ExistingOrder_DeletesOrder()
        {
            // Arrange
            var orderId = 1;
            mockOrderDao.Setup(dao => dao.DeleteAsync(orderId));

            // Act
            await orderLogic.DeleteAsync(orderId);

            // Assert
            mockOrderDao.Verify(dao => dao.DeleteAsync(orderId), Times.Once);
        }

        [Test]
        public async Task DeleteAsync_NonExistingOrder_ThrowsException()
        {
            // Arrange
            var nonExistingOrderId = 999;
            mockOrderDao.Setup(dao => dao.DeleteAsync(nonExistingOrderId)).ThrowsAsync(new Exception("Order not found"));

            // Act & Assert
            var exception = Assert.ThrowsAsync<Exception>(async () => await orderLogic.DeleteAsync(nonExistingOrderId));
            Assert.AreEqual("Order not found", exception.Message);
        }
        
        [Test]
        public async Task DeleteItemFromOrder_InvalidOrderItem_ThrowsException()
        {
            // Arrange
            var invalidOrderItem = new OrderItem
            {
                Id = 1,
                ItemId = -1,
                OrderId = -3999,
                Quantity = 0
            };

            mockOrderDao.Setup(dao => dao.DeleteItemFromOrder(invalidOrderItem)).ThrowsAsync(new Exception("Invalid order item"));

            // Act & Assert
            var exception = Assert.ThrowsAsync<Exception>(async () => await orderLogic.DeleteItemFromOrder(invalidOrderItem));
            Assert.AreEqual("Invalid order item", exception.Message);
        }
        
        [Test]
        public async Task GetAsync_WithSearchParameters_ReturnsFilteredOrders()
        {
            // Arrange
            var searchParameters = new SearchOrderParametersDto("John Doe", null, null, null, null, null, null);

            var expectedFilteredOrders = new List<Order>
            {
                new Order()
                {
                    Id = 1,
                    OrderFullName = "John Doe",
                    PostCode = 8700,
                    Address = "Address 1",
                    City = "Horsens",
                    PhoneNumber = 4512345678,
                    Status = "in progress",
                    Date = "2023-12-08",
                    Items = {new OrderItem()
                    {
                        Id = 1,
                        ItemId = 1,
                        OrderId = 1,
                        Quantity = 3
                    }},
                    UserId = 1
                }
            };

            mockOrderDao.Setup(dao => dao.GetAsync(searchParameters)).ReturnsAsync(expectedFilteredOrders);

            // Act
            var filteredOrders = await orderLogic.GetAsync(searchParameters);

            // Assert
            Assert.NotNull(filteredOrders);
            Assert.AreEqual(expectedFilteredOrders.Count, filteredOrders.Count());
            // Add more assertions as needed
        }
}