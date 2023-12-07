using Domain.DTOs.Item;
using Domain.DTOs.OrderItem;

namespace Domain.DTOs.Order;

public class DisplayOrderDto
{
    public string OrderFullName { get; }
    public int PostCode { get; }
    public string Address { get; }
    public string City { get; }
    public long PhoneNumber { get; }
    public string Status { get; }
    public string Date { get; }
    public List<DisplayOrderItemDto> OrderItems { get; }

    public DisplayOrderDto(string orderFullName, int postCode, string address, string city, long phoneNumber, string status, string date, List<DisplayOrderItemDto> orderItems)
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