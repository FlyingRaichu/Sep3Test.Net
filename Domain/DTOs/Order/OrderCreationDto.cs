using System.Text.Json.Serialization;
using Domain.DTOs.OrderItem;

namespace Domain.DTOs.Order;

public class OrderCreationDto
{
    public string OrderFullName { get; set; }
    public int PostCode { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public long PhoneNumber { get; set; }
    public string Status { get; set; }
    public string Date { get; set; }
    public List<OrderItemCreationDto>? OrderItems { get; set; }
    public int? UserId { get; set; }

    [JsonConstructor]
    public OrderCreationDto(string orderFullName, int postCode, string address, string city, long phoneNumber,
        string status, string date, List<OrderItemCreationDto>? orderItems, int? userId)
    {
        OrderFullName = orderFullName;
        PostCode = postCode;
        Address = address;
        City = city;
        PhoneNumber = phoneNumber;
        Status = status;
        Date = date;
        OrderItems = orderItems ?? new List<OrderItemCreationDto>();
        UserId = userId;
    }
}