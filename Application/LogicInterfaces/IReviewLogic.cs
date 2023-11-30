using Domain.DTOs.Review;

namespace Application.LogicInterfaces;

public interface IReviewLogic
{
    Task<Review> CreateAsync(ReviewCreationDto dto);
    Task DeleteAsync(int id);
    Task<Review> GetByIdAsync(int id);
    Task<IEnumerable<Review>> GetAllWithIdAsync(List<int> ids);
}