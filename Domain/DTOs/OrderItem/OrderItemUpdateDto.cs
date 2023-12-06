namespace Domain.DTOs.OrderItem;

public class OrderItemUpdateDto
{
    public int Id { get; }
    public int OrderId { get; }
    public int? Quantity { get; set; }

    public OrderItemUpdateDto(int id, int orderId)
    {
        Id = id;
        OrderId = orderId;
    }
}