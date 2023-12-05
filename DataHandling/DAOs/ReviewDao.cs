using Application.DaoInterfaces;
using RPCInterface.RPCInterfaces;

namespace DataHandling.DAOs;

public class ReviewDao : IReviewDao
{
    private readonly IReviewRpc context;

    public ReviewDao(IReviewRpc context)
    {
        this.context = context;
    }

    public Task<Review> CreateAsync(Review review)
    {
        int id = 1;
        if (context.Elements.Any())
        {
            id = context.Elements.Max(i => i.Id);
            id++;
        }

        review.Id = id;

        context.Add(review);
        return Task.FromResult(review);
    }

    public Task DeleteAsync(int id)
    {
        context.Delete(id);
        return Task.CompletedTask;
    }

    public Task<Review?> GetByIdAsync(int id)
    {
        var review = context.Elements.FirstOrDefault(r => r.Id == id);
        return Task.FromResult<Review>(review);
    }

    public async Task<ICollection<Review>> GetAllWithIdAsync(List<int> ids)
    {
        IntListRequest idList = new IntListRequest();
        foreach (var id in ids)
        {
            idList.Values.Add(id);
        }

        ICollection<Review> reviews = context.GetAllWithId(idList).Result;
        return await Task.FromResult(reviews);
    }

    public async Task<ICollection<Review>> GetAllReviewsByItemIdAsync(int itemId)
    {
        return await context.GetAllReviewsByItemIdAsync(itemId);
    }
}