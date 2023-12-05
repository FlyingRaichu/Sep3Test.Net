using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs.Review;

namespace Application.Logic;

public class ReviewLogic : IReviewLogic
{
    private readonly IReviewDao reviewDao;
    private readonly IItemDao itemDao;

    public ReviewLogic(IReviewDao reviewDao, IItemDao itemDao)
    {
        this.reviewDao = reviewDao;
        this.itemDao = itemDao;
    }

    public async Task<Review> CreateAsync(ReviewCreationDto dto)
    {
        Item? item = await itemDao.GetByIdAsync(dto.ItemId);
        if (item == null)
        {
            throw new Exception("item not found");
        }
        //Console.WriteLine(item.ToString());
        ValidateReview(dto);
        var review = new Review
        {
            Content = dto.Content,
            Rating = dto.Rating,
            Username = dto.Username,
            ItemId = item
        };
        var created = await reviewDao.CreateAsync(review);
        Console.WriteLine(review.ToString());
        return created;
    }

    private void ValidateReview(ReviewCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Content))
        {
            throw new Exception("The review can't be empty");
        }

        if (string.IsNullOrEmpty(dto.Username))
        {
            throw new Exception("User was not found");
        }

        if (dto.Rating is < 1 or > 5)
        {
            throw new Exception("Rating must be between 1 and 5 included.");
        }
    }

    public async Task DeleteAsync(int id)
    {
        await reviewDao.DeleteAsync(id);
    }

    public async Task<Review> GetByIdAsync(int id)
    {
        var review = await reviewDao.GetByIdAsync(id);

        if (review == null)
        {
            throw new Exception($"Review with it {id} does not exist");
        }

        return review;
    }

    public async Task<ICollection<Review>> GetAllWithIdAsync(List<int> ids)
    {
        return await reviewDao.GetAllWithIdAsync(ids);
    }

    public async Task<ICollection<Review>> GetAllReviewsByItemIdAsync(int itemId)
    {
        return await reviewDao.GetAllReviewsByItemIdAsync(itemId);
    }
}