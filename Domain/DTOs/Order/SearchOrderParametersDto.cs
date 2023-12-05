namespace Domain.DTOs.Order;

public class SearchOrderParametersDto
{
    public string? OrderFullName { get; }
    public int? PostCode { get; }
    public string? Address { get; }
    public string? City { get; }
    public long? PhoneNumber { get; }
    public string? Status { get; }
    public string? Date { get; }

    public SearchOrderParametersDto(string? orderFullName, int? postCode, string? address, string? city, long? phoneNumber, string? status, string? date)
    {
        OrderFullName = orderFullName;
        PostCode = postCode;
        Address = address;
        City = city;
        PhoneNumber = phoneNumber;
        Status = status;
        Date = date;
    }
}