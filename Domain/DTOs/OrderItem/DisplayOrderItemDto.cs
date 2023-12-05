using Domain.DTOs.Item;

namespace Domain.DTOs.OrderItem;

public class DisplayOrderItemDto
{
    public int ItemId { get;}
    public int OrderId { get; }
    public int Quantity { get; }

    public DisplayOrderItemDto(int itemId, int orderId, int quantity)
    {
        ItemId = itemId;
        OrderId = orderId;
        Quantity = quantity;
    }
}