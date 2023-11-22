using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs.Address;
using proto;

namespace Application.Logic;

public class AddressLogic : IAddressLogic
{
    private readonly IAddressDao addressDao;

    public AddressLogic(IAddressDao addressDao)
    {
        this.addressDao = addressDao;
    }

    public Task<IEnumerable<Address>> GetAsync(SearchAddressParametersDto searchParameters)
    {
        return addressDao.GetAsync(searchParameters);
    }

    public async Task<Address> CreateAsync(AddressCreationDto dto)
    {
        ValidateAddress(dto);
        var address = new Address
        {
            Address_ = dto.Address,
            ApartmentNr = dto.Apartment,
            PostalCode = dto.PostalCode,
            City = dto.City
        };
        var created = await addressDao.CreateAsync(address);
        return created;
    }

    private static void ValidateAddress(AddressCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Address) || dto.PostalCode == null || string.IsNullOrEmpty(dto.City))
        {
            throw new Exception("The address, postal code and city can't be empty");
        }

        if (dto.PostalCode.Length < 4)
        {
            throw new Exception("The postal code is invalid");
        }
    }
}