using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs.OrderItem;
using proto;

namespace Application.Logic;

public class OrderItemLogic : IOrderItemLogic
{
    private readonly IOrderItemDao orderItemDao;
    private readonly IItemDao itemDao;

    public OrderItemLogic(IOrderItemDao orderItemDao, IItemDao itemDao)
    {
        this.orderItemDao = orderItemDao;
        this.itemDao = itemDao;
    }

    public Task<IEnumerable<OrderItem>> GetAsync(SearchOrderItemParametersDto searchParameters)
    {
        return orderItemDao.GetAsync(searchParameters);
    }

    public async Task<OrderItem> CreateAsync(OrderItemCreationDto dto)
    {
        ValidateOrderItem(dto);
        var orderItem = new OrderItem
        {
            Amount = dto.Amount,
            ItemId = dto.ItemId
        };
        var created = await orderItemDao.CreateAsync(orderItem);
        return created;
    }

    private void ValidateOrderItem(OrderItemCreationDto dto)
    {
        if (dto.Amount == 0)
        {
            throw new Exception("You must select at least 1 item.");
        }

        var result = itemDao.GetItemByIdAsync(dto.ItemId).Result;
        if (result == null)
        {
            throw new Exception("The item was not found");
        }
    }
}