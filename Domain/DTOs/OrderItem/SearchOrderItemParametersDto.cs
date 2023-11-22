namespace Domain.DTOs.OrderItem;

public class SearchOrderItemParametersDto
{
    public int Amount { get; }
    public int ItemId { get; }

    public SearchOrderItemParametersDto(int amount, int itemId)
    {
        Amount = amount;
        ItemId = itemId;
    }
}