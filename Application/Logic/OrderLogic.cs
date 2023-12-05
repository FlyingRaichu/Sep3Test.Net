using System.ComponentModel;
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
            Date = dto.Date,
            UserId = dto.UserId.Value,
        };
        
        var orderItems = dto.OrderItems.Select(itemDto => new OrderItem
            { Quantity = itemDto.Quantity, ItemId = itemDto.ItemId, OrderId = itemDto.OrderId }).ToList();
        
        order.Items.AddRange(orderItems);
        var created = await orderDao.CreateAsync(order);
        return created;
    }

    public async Task UpdateAsync(OrderUpdateDto dto)
    {
        var existing = await GetByIdAsync(dto.Id);

        var orderFullName = dto.OrderFullName ?? existing.OrderFullName;
        var postalCode = dto.PostCode ?? existing.PostCode;
        var address = dto.Address ?? existing.Address;
        var city = dto.City ?? existing.City;
        var phoneNumber = dto.PhoneNumber ?? existing.PhoneNumber;
        var status = dto.Status ?? existing.Status;
        var date = dto.Date ?? existing.Date;

        List<OrderItem> orderItems = new List<OrderItem>();
        if (dto.OrderItems != null)
        {
            foreach (var item in dto.OrderItems)
            {
                var orderItem = new OrderItem
                {
                    ItemId = item.ItemId,
                    OrderId = item.OrderId,
                    Quantity = item.Quantity
                };
                orderItems.Add(orderItem);
            }
        }

        Order order = new()
        {
            OrderFullName = orderFullName,
            PostCode = postalCode,
            Address = address,
            City = city,
            PhoneNumber = phoneNumber,
            Status = status,
            Date = date
        };
        order.Items.AddRange(orderItems);
        
        ValidateOrder(order);
        await orderDao.UpdateAsync(order);
    }

    public async Task DeleteAsync(int id)
    {
        await orderDao.DeleteAsync(id);
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        var order = await orderDao.GetByIdAsync(id);

        if (order == null)
        {
            throw new Exception($"Order with Id {id} does not exist.");
        }

        return order;
    }

    public async Task<OrderItem> AddItemToOrder(OrderItemCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateItemInOrder(OrderItemUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteItemFromOrder(OrderItem orderItem)
    {
        await orderDao.DeleteItemFromOrder(orderItem);
    }

    private static void ValidateOrder(OrderCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.OrderFullName))
            throw new Exception("The name must be filled out");

        if (dto.PostCode is < 9999 and > 1000)
            throw new Exception("The postal code is invalid.");

        if (string.IsNullOrEmpty(dto.Address))
            throw new Exception("The address must be filled out");

        if (string.IsNullOrEmpty(dto.City))
            throw new Exception("The city must be filled out.");

        if (dto.PhoneNumber is < 4599999999 and > 4500000000)
            throw new Exception("invalid phone number.");

        if (!dto.OrderItems.Any())
            throw new Exception("The order needs to have items");
    }
    
    private static void ValidateOrder(Order order)
    {
        if (order == null)
            throw new Exception("The order was not created.");
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