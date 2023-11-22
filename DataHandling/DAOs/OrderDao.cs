using Application.DaoInterfaces;
using Domain.DTOs.Order;
using proto;
using RPCInterface.RPCImplementations;

namespace DataHandling.DAOs;

public class OrderDao : IOrderDao
{
    private readonly IRpcBase<Order> orderContext;
    private readonly IRpcBase<Address> addressContext;
    private readonly IRpcBase<FullName> fullNameContext;
    private readonly IRpcBase<OrderItem> orderItemContext;

    public OrderDao(IRpcBase<Order> orderContext, IRpcBase<Address> addressContext, IRpcBase<FullName> fullNameContext, IRpcBase<OrderItem> orderItemContext)
    {
        this.orderContext = orderContext;
        this.addressContext = addressContext;
        this.fullNameContext = fullNameContext;
        this.orderItemContext = orderItemContext;
    }

    public Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto searchParameters)
    {
        IEnumerable<Order> orders = orderContext.Elements.AsEnumerable();
        
        if (!string.IsNullOrEmpty(searchParameters.Username))
        {
            orders = orderContext.Elements.Where(order =>
                order.Username.Contains(searchParameters.Username, StringComparison.OrdinalIgnoreCase));
        }

        if (searchParameters.AddressId != null)
        {
            orders = orderContext.Elements.Where(order => order.Address.Id == searchParameters.AddressId);
        }
        
        if (searchParameters.FullNameId != null)
        {
            orders = orderContext.Elements.Where(order => order.FullName.Id == searchParameters.FullNameId);
        }
        
        if (searchParameters.Price != null)
        {
            orders = orderContext.Elements.Where(order => order.Price == searchParameters.Price);
        }

        return Task.FromResult(orders);
    }

    public Task<Order> CreateAsync(Order order)
    {
        int id = 1;
        if (orderContext.Elements.Any())
        {
            id = orderContext.Elements.Max(i => i.Id);
            id++;
        }

        order.Id = id;

        orderContext.Add(order);
        return Task.FromResult(order);

    }
}