using Domain.DTOs.Review;

namespace Application.LogicInterfaces;

public interface IReviewLogic
{
    Task<Review> CreateAsync(ReviewCreationDto dto);
    Task DeleteAsync(int id);
    Task<Review> GetByIdAsync(int id);
    Task<ICollection<Review>> GetAllWithIdAsync(List<int> ids);
    Task<ICollection<Review>> GetAllReviewsByItemIdAsync(int itemId);
}