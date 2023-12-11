using Domain.DTOs.DiscountCode;

namespace HttpClients.Interfaces;

public interface IDiscountCodeService
{
    Task<DiscountCode> CreateAsync(DiscountCodeDto dto);
    Task DeleteAsync(int id);

    Task<ICollection<DiscountCode>> GetDiscountCodesAsync(
        string? code,
        int? discountPercentage);
    // Additional methods and properties can be added based on your requirements.
}
