namespace Domain.DTOs.OrderItem;

public class OrderItemCreationDto
{
    public int Amount { get; }
    public int ItemId { get; }

    public OrderItemCreationDto(int amount, int itemId)
    {
        Amount = amount;
        ItemId = itemId;
    }
}