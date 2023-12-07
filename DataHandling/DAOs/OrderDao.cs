using Application.DaoInterfaces;
using Domain.DTOs.Order;
using RPCInterface.RPCInterfaces;

namespace DataHandling.DAOs;

public class OrderDao : IOrderDao
{
    private readonly IRpcOrder context;

    public OrderDao(IRpcOrder context)
    {
        this.context = context;
    }

    public Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto searchOrderParameters)
    {
        IEnumerable<Order> orders = context.Elements.AsEnumerable();

        if (!string.IsNullOrEmpty(searchOrderParameters.OrderFullName))
            orders = orders.Where(order =>
                order.OrderFullName.Equals(searchOrderParameters.OrderFullName, StringComparison.OrdinalIgnoreCase));

        if (searchOrderParameters.PostCode != null)
            orders = orders.Where(order => order.PostCode == searchOrderParameters.PostCode);
        
        if (!string.IsNullOrEmpty(searchOrderParameters.Address))
            orders = orders.Where(order =>
                order.Address.Equals(searchOrderParameters.Address, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrEmpty(searchOrderParameters.City))
            orders = orders.Where(order =>
                order.City.Equals(searchOrderParameters.City, StringComparison.OrdinalIgnoreCase));

        if (searchOrderParameters.PhoneNumber != null)
            orders = orders.Where(order => order.PhoneNumber == searchOrderParameters.PhoneNumber);

        if (!string.IsNullOrEmpty(searchOrderParameters.Status))
            orders = orders.Where(order =>
                order.Status.Equals(searchOrderParameters.Status, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrEmpty(searchOrderParameters.Date))
            orders = orders.Where(order =>
                order.Date.Equals(searchOrderParameters.Date, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(orders);
    }

    public Task<Order> CreateAsync(Order order)
    {
        var id = 1;
        if (context.Elements.Any())
        {
            id = context.Elements.Max(i => i.Id);
            id++;
        }

        order.Id = id;
        
        context.Add(order);
        return Task.FromResult(order);
    }

    public Task UpdateAsync(Order order)
    {
        context.Update(order);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        context.Delete(id);
        return Task.CompletedTask;
    }

    public Task<Order> GetByIdAsync(int id)
    {
        var order = context.Elements.FirstOrDefault(i => i.Id == id);
        return Task.FromResult<Order>(order);
    }
    
    public Task<IEnumerable<Order>> GetAllByUserIdAsync(int userId)
    {
        var orders = context.Elements.Where(order => order.UserId == userId);
        return Task.FromResult(orders);
    }

    public Task<OrderItem> AddItemToOrder(OrderItem orderItem)
    {
        context.AddItemToOrder(orderItem);
        return Task.FromResult(orderItem);
    }

    public Task UpdateItemInOrder(OrderItem orderItem)
    {
        context.UpdateItemInOrder(orderItem);
        return Task.CompletedTask;
    }

    public Task DeleteItemFromOrder(OrderItem orderItem)
    {
        context.DeleteItemFromOrder(orderItem);
        return Task.CompletedTask;
    }
}