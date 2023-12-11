using Domain.DTOs;
using Domain.DTOs.DiscountCode;
using Google.Protobuf.WellKnownTypes;

namespace Application.DaoInterfaces;

public interface IDiscountCodeDao
{
    Task<DiscountCode> CreateAsync(DiscountCode request);
    Task DeleteAsync(int id);
    Task<IEnumerable<DiscountCode>> GetAsync(SearchDiscountParametersDto searchParameters);
    
}
