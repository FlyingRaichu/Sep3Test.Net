namespace Domain.DTOs.Order;

public class OrderUpdateDto
{
    public int Id { get; }
    public string? OrderFullName { get; set; }
    public int? PostCode { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public int? PhoneNumber { get; set; }
    public string? Status { get; set; }
    public string? Date { get; set; }
    public List<OrderCreationDto>? OrderItems { get; set; }

    public OrderUpdateDto(int id)
    {
        Id = id;
    }
}