using Domain.DTOs.Order;
using proto;

namespace Application.LogicInterfaces;

public interface IOrderLogic
{
    Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto searchParameters);
    Task<Order> CreateAsync(OrderCreationDto dto);
}