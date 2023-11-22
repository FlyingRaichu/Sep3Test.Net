namespace Domain.DTOs.Address;

public class AddressCreationDto
{
    public string Address { get; }
    public string? Apartment { get; }
    public string PostalCode { get; }
    public string City { get; }

    public AddressCreationDto(string address, string? apartment, string postalCode, string city)
    {
        Address = address;
        Apartment = apartment;
        PostalCode = postalCode;
        City = city;
    }
}