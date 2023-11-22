namespace Domain.DTOs.Order;

public class SearchOrderParametersDto
{
    public string? Username { get; }
    public int? AddressId { get; }
    public int? FullNameId { get; }
    public double? Price { get; }

    public SearchOrderParametersDto(string? username, int? addressId, int? fullNameId, double? price)
    {
        Username = username;
        AddressId = addressId;
        FullNameId = fullNameId;
        Price = price;
    }
}