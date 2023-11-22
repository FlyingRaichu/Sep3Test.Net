using Application.DaoInterfaces;
using Domain.DTOs.OrderItem;
using proto;
using RPCInterface.RPCImplementations;

namespace DataHandling.DAOs;

public class OrderItemDao : IOrderItemDao
{
    private readonly IRpcBase<OrderItem> orderItemContext;
    private readonly IRpcBase<Item> itemContext;

    public OrderItemDao(IRpcBase<OrderItem> orderItemContext, IRpcBase<Item> itemContext)
    {
        this.orderItemContext = orderItemContext;
        this.itemContext = itemContext;
    }

    public async Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemParametersDto searchParameters)
    {
        throw new NotImplementedException("how exactly to implement it");
    }

    public async Task<OrderItem> CreateAsync(OrderItem orderItem)
    {
        Item? item = await itemContext.GetByIdAsync(orderItem.ItemId);
        if (item == null)
        {
            throw new Exception("Could not find the item.");
        }
        int id = 1;
        if (orderItemContext.Elements.Any())
        {
            id = orderItemContext.Elements.Max(i => i.Id);
            id++;
        }

        orderItem.Id = id;
        await orderItemContext.Add(orderItem);
        return await Task.FromResult(orderItem);
    }
}