namespace Application.DaoInterfaces;

public interface IReviewDao
{
    Task<Review> CreateAsync(Review review);
    Task DeleteAsync(int id);
    Task<Review?> GetByIdAsync(int id);
    Task<IEnumerable<Review>> GetAllWithIdAsync(List<int> ids);
}