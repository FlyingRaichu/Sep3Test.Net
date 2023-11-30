using Domain.DTOs.Review;

namespace HttpClients.Interfaces;

public interface IReviewService
{
    Task<Review> CreateAsync(ReviewCreationDto dto);
    Task DeleteAsync(int id);
    Task<Review> GetByIdAsync(int id);
    Task<IEnumerable<Review>> GetAllWithIdAsync(List<int> ids);
}