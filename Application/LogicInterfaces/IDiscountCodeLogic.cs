using Domain.DTOs.DiscountCode;

namespace Application.LogicInterfaces;

public interface IDiscountCodeLogic
{
    Task<DiscountCode> CreateAsync(DiscountCodeDto dto);
    Task<IEnumerable<DiscountCode>> GetAsync(SearchDiscountParametersDto searchParameters);
    Task DeleteAsync(int id);
    
}