namespace Application.DaoInterfaces;

public interface IReviewDao
{
    Task<Review> CreateAsync(Review review);
    Task DeleteAsync(int id);
    Task<Review?> GetByIdAsync(int id);
    Task<ICollection<Review>> GetAllWithIdAsync(List<int> ids);
    Task<ICollection<Review>> GetAllReviewsByItemIdAsync(int itemId);
}