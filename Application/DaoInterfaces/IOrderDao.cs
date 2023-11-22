using Domain.DTOs;
using Domain.DTOs.Order;
using proto;

namespace Application.DaoInterfaces;

public interface IOrderDao
{
    Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto searchParameter);
    Task<Order> CreateAsync(Order order);
}