namespace Domain.DTOs.OrderItem;

public class OrderItemUpdateDto
{
    public int Id { get; }
    public int? Quantity { get; set; }

    public OrderItemUpdateDto(int id)
    {
        Id = id;
    }
}