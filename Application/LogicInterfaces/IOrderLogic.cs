using Domain.DTOs.Order;
using Domain.DTOs.OrderItem;

namespace Application.LogicInterfaces;

public interface IOrderLogic
{
    Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto searchOrderParameters);
    Task<Order> CreateAsync(OrderCreationDto dto);
    Task UpdateAsync(OrderUpdateDto dto);
    Task DeleteAsync(int id);

    Task<Order> GetByIdAsync(int id);

    Task<OrderItem> AddItemToOrder(OrderItemCreationDto dto);
    Task UpdateItemInOrder(OrderItemUpdateDto dto);
    Task DeleteItemFromOrder(OrderItem orderItem);
    Task<IEnumerable<Order>> GetAllByUserIdAsync(int userId);
}