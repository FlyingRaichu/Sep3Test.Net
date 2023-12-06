using Domain.DTOs.Order;
using Domain.DTOs.OrderItem;

namespace HttpClients.Interfaces;

public interface IOrderService
{
    Task<ICollection<Order>> GetOrdersAsync(
        string? orderFullName,
        int? postalCode,
        string? address,
        string? city,
        long? phoneNumber,
        string? status,
        string? date
    );

    Task<Order> CreateAsync(OrderCreationDto dto);
    Task UpdateAsync(OrderUpdateDto dto);
    Task DeleteAsync(int id);
    Task<Order> GetByIdAsync(int id);

    Task<OrderItem> AddItemToOrderAsync(OrderItemCreationDto dto);
    Task UpdateItemInOrderAsync(OrderItemUpdateDto dto);
    Task DeleteItemInOrderAsync(int orderItemId, int orderId);
}