namespace Domain.DTOs.Address;

public class SearchAddressParametersDto
{
    public int? Id { get; }
    public string? Address { get; }
    public string? Apartment { get; }
    public string? PostalCode { get; }
    public string? City { get; }

    public SearchAddressParametersDto(int? id, string? address, string? apartment, string? postalCode, string? city)
    {
        Id = id;
        Address = address;
        Apartment = apartment;
        PostalCode = postalCode;
        City = city;
    }
}