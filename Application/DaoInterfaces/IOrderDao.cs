using Domain.DTOs.Order;
using Domain.DTOs.OrderItem;

namespace Application.DaoInterfaces;

public interface IOrderDao
{
    Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto searchOrderParameters);
    Task<Order> CreateAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(int id);

    Task<Order> GetByIdAsync(int id);

    Task<OrderItem> AddItemToOrder(OrderItem orderItem);
    Task UpdateItemInOrder(OrderItem orderItem);
    Task DeleteItemFromOrder(int orderId);
}