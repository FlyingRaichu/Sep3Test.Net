using Domain.DTOs.Address;
using proto;

namespace Application.DaoInterfaces;

public interface IAddressDao
{
    Task<IEnumerable<Address>> GetAsync(SearchAddressParametersDto searchParameters);
    Task<Address> CreateAsync(Address address);
    Task<Address?> GetAddressByIdAysinc(int id);
}