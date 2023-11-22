using Application.DaoInterfaces;
using Domain.DTOs.Order;
using proto;
using RPCInterface.RPCImplementations;

namespace DataHandling.DAOs;

public class OrderDao : IOrderDao
{
    private readonly IRpcBase<Order> context;

    public OrderDao(IRpcBase<Order> context)
    {
        this.context = context;
    }

    public Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto searchParameter)
    {
        // IEnumerable<Order> orders = context.Elements.AsEnumerable();
        throw new NotImplementedException();
    }

    public Task<Order> CreateAsync(Order order)
    {
        int id = 1;
        if (context.Elements.Any())
        {
            id = context.Elements.Max(i => i.Id);
            id++;
        }

        order.Id = id;

        context.Add(order);
        return Task.FromResult(order);

    }
}