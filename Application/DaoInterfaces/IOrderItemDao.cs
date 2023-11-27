using Domain.DTOs.OrderItem;
using proto;

namespace Application.DaoInterfaces;

public interface IOrderItemDao
{
    Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemParametersDto searchParameters);
    Task<OrderItem> CreateAsync(OrderItem orderItem);
    Task<OrderItem?> GetOrderItemByIdAsync(int id);
}