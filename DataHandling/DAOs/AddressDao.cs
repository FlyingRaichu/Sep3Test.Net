using Application.DaoInterfaces;
using Domain.DTOs.Address;
using proto;
using RPCInterface.RPCImplementations;

namespace DataHandling.DAOs;

public class AddressDao : IAddressDao
{
    private readonly IRpcBase<Address> context;

    public AddressDao(IRpcBase<Address> context)
    {
        this.context = context;
    }

    public Task<IEnumerable<Address>> GetAsync(SearchAddressParametersDto searchParameters)
    {
        IEnumerable<Address> addresses = context.Elements.AsEnumerable();

        if (searchParameters.Id != null)
        {
            addresses = context.Elements.Where(address => address.Id == searchParameters.Id);
        }

        if (!string.IsNullOrEmpty(searchParameters.Address))
        {
            addresses = context.Elements.Where(address =>
                address.Address_.Contains(searchParameters.Address, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(searchParameters.Apartment))
        {
            addresses = context.Elements.Where(address =>
                address.ApartmentNr.Contains(searchParameters.Apartment, StringComparison.OrdinalIgnoreCase));
        }
        
        if (!string.IsNullOrEmpty(searchParameters.PostalCode))
        {
            addresses = context.Elements.Where(address =>
                address.PostalCode.Contains(searchParameters.PostalCode, StringComparison.OrdinalIgnoreCase));
        }
        
        if (!string.IsNullOrEmpty(searchParameters.City))
        {
            addresses = context.Elements.Where(address =>
                address.City.Contains(searchParameters.City, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(addresses);
    }

    public Task<Address> CreateAsync(Address address)
    {
        int id = 1;
        if (context.Elements.Any())
        {
            id = context.Elements.Max(i => i.Id);
            id++;
        }

        address.Id = id;
        return Task.FromResult(address);
    }
}