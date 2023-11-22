

namespace Domain.DTOs.Order;

public class OrderCreationDto
{
    public string? Username { get; }
    public int AddressId { get; }
    public int FullNameId { get; }
    public double Price { get; }
    public List<int> OrderItemIds { get; }

    public OrderCreationDto(string? username, int addressId, int fullNameId, double price, List<int> orderItemIds)
    {
        Username = username;
        AddressId = addressId;
        FullNameId = fullNameId;
        Price = price;
        OrderItemIds = orderItemIds;
    }
}