using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs.Order;
using proto;

namespace Application.Logic;

public class OrderLogic : IOrderLogic
{
    private readonly IOrderDao orderDao;
    private readonly IAddressDao addressDto;
    private readonly IFullNameDao fullNameDto;
    private readonly IOrderItemDao orderItemDto;
    //private readonly IUserDao userDto;


    public OrderLogic(IOrderDao orderDao, IAddressDao addressDto, IFullNameDao fullNameDto, IOrderItemDao orderItemDto/*, IUserDao userDto*/)
    {
        this.orderDao = orderDao;
        this.addressDto = addressDto;
        this.fullNameDto = fullNameDto;
        this.orderItemDto = orderItemDto;
        //this.userDto = userDto;
    }


    public Task<IEnumerable<Order>> GetAsync(SearchOrderParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<Order> CreateAsync(OrderCreationDto dto)
    {
        throw new NotImplementedException();
    }
}