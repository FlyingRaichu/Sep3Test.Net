using System.Text.Json.Serialization;
using Domain.DTOs.OrderItem;

namespace Domain.DTOs.Order;

public class OrderCreationDto
{
    public string OrderFullName { get; }
    public int PostCode { get; }
    public string Address { get; }
    public string City { get; }
    public long PhoneNumber { get; }
    public string Status { get; }
    public string Date { get; }
    public List<OrderItemCreationDto> OrderItems { get; }
    public int? UserId { get; }

    [JsonConstructor]
    public OrderCreationDto(string orderFullName, int postCode, string address, string city, long phoneNumber,
        string status, string date, List<OrderItemCreationDto> orderItems)
    {
        OrderFullName = orderFullName;
        PostCode = postCode;
        Address = address;
        City = city;
        PhoneNumber = phoneNumber;
        Status = status;
        Date = date;
        OrderItems = orderItems;
    }
}