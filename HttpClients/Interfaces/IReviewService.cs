using Domain.DTOs.Review;

namespace HttpClients.Interfaces;

public interface IReviewService
{
    Task<Review> CreateAsync(ReviewCreationDto dto, string token);
    Task DeleteAsync(int id);
    Task<Review> GetByIdAsync(int id);
    Task<ICollection<Review>> GetAllWithIdAsync(List<int> ids);
    Task<ICollection<Review>> GetAllReviewsByItemIdAsync(int itemId);
}