using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs.Order;
using Domain.DTOs.OrderItem;

namespace Application.Logic;

public class OrderLogic : IOrderLogic
{
    private readonly IOrderDao orderDao;

    public OrderLogic(IOrderDao orderDao)
    {
        this.orderDao = orderDao;
    }

    public Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto searchOrderParameters)
    {
        return orderDao.GetAsync(searchOrderParameters);
    }

    public async Task<Order> CreateAsync(OrderCreationDto dto)
    {
        ValidateOrder(dto);
        var order = new Order
        {
            OrderFullName = dto.OrderFullName,
            PostCode = dto.PostCode,
            Address = dto.Address,
            City = dto.City,
            PhoneNumber = dto.PhoneNumber,
            Status = dto.Status,
            Date = dto.Date
        };
        var orderItems = dto.OrderItems.Select(itemDto => new OrderItem
            { Quantity = itemDto.Quantity, ItemId = itemDto.ItemId, OrderId = itemDto.OrderId }).ToList();
        
        order.Items.AddRange(orderItems);
        var created = await orderDao.CreateAsync(order);
        return created;
    }

    public async Task UpdateAsync(OrderUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderItem> AddItemToOrder(OrderItemCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateItemInOrder(OrderItemUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteItemFromOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    private static void ValidateOrder(OrderCreationDto dto)
    {
        throw new NotImplementedException();
    }
    
    private static void ValidateOrder(Order order)
    {
        throw new NotImplementedException();
    }

    private static void ValidateOrderItem(OrderItemCreationDto dto)
    {
        throw new NotImplementedException();
    }

    private static void ValidateOrderItem(OrderItem orderItem)
    {
        throw new NotImplementedException();
    }
}