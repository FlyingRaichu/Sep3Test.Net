using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs.Order;
using Google.Protobuf.Collections;
using Grpc.Core;
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

    public async Task<Order> CreateAsync(OrderCreationDto dto)
    {
        ValidateOrder(dto);
        //User? user = UserDto
        Address? address = await addressDto.GetAddressByIdAysinc(dto.AddressId);
        FullName? fullName = await fullNameDto.GetFullNameById(dto.FullNameId);
        List<OrderItem> orderItems = new List<OrderItem>();
        foreach (var id in dto.OrderItemIds)
        {
            OrderItem? temp = await orderItemDto.GetOrderItemByIdAsync(id);
            if (temp == null)
            {
                throw new Exception("The order item was not found");
            }
            orderItems.Add(temp);
        }

        Console.WriteLine($"#### order item list : {orderItems[0]}, {orderItems[1]}");
        Console.WriteLine($"### address: {address}");
        Console.WriteLine($"### full name: {fullName}");
        
        var order = new Order
        {
            Username = dto.Username,
            Address = address,
            FullName = fullName,
            Price = dto.Price
            //OrderItems = 
        };

        var created = await orderDao.CreateAsync(order);
        return created;

    }

    private void ValidateOrder(OrderCreationDto dto)
    {
        if (dto.AddressId == 0 || dto.FullNameId == 0)
        {
            throw new Exception("The address and full name must be added");
        }

        if (!dto.OrderItemIds.Any())
        {
            throw new Exception("There must be items in the order");
        }
    }
}