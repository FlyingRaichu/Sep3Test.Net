using Domain.DTOs.OrderItem;
using proto;

namespace Application.LogicInterfaces;

public interface IOrderItemLogic
{
    Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemParametersDto searchParameters);
    Task<OrderItem> CreateAsync(OrderItemCreationDto dto);
}