using Domain.DTOs.Address;
using proto;

namespace Application.LogicInterfaces;

public interface IAddressLogic
{
    Task<IEnumerable<Address>> GetAsync(SearchAddressParametersDto searchParameters);
    Task<Address> CreateAsync(AddressCreationDto dto);
}