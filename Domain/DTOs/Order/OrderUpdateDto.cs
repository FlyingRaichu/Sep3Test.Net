using System.Text.Json.Serialization;
using Domain.DTOs.OrderItem;

namespace Domain.DTOs.Order;

public class OrderUpdateDto
{
    public int Id { get; }
    public string? OrderFullName { get; set; }
    public int? PostCode { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public long? PhoneNumber { get; set; }
    public string? Status { get; set; }
    public string? Date { get; set; }
    public List<OrderItemCreationDto>? OrderItems { get; set; }

    
    [JsonConstructor]
    public OrderUpdateDto(int id)
    {
        Id = id;
    }
}