namespace Domain.DTOs.OrderItem;

public class OrderItemCreationDto
{
    public int ItemId { get; }
    public int OrderId { get; }
    public int Quantity { get; }

    public OrderItemCreationDto(int itemId, int orderId, int quantity)
    {
        ItemId = itemId;
        OrderId = orderId;
        Quantity = quantity;
    }
}