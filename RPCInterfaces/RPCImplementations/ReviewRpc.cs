using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using RPCInterface.RPCInterfaces;

namespace RPCInterface.RPCImplementations;

public class ReviewRpc : IReviewRpc
{
    private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8090");

    public ICollection<Review> Elements => LoadData().Result;
    
    public async Task<ICollection<Review>> LoadData()
    {
        var empty = new Empty();
        var client = new ReviewService.ReviewServiceClient(channel);
        var reviews = new List<Review>();
        var response = client.getAllReviews(empty);

        await foreach (var item in response.ResponseStream.ReadAllAsync())
        {
            reviews.Add(item);
        }

        //Console.WriteLine($"###{reviews.ToString() }");
        return reviews;
    }

    public Task Add(Review element)
    {
        var client = new ReviewService.ReviewServiceClient(channel);
        try
        {
            var response = client.addReview(element);
            Elements.Add(element);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }

    public Task Update(Review element)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        var client = new ReviewService.ReviewServiceClient(channel);

        try
        {
            Review? review = Elements.FirstOrDefault(i => i.Id == id);
            var response = client.deleteReview(review);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        return Task.CompletedTask;
    }
    
    public async Task<ICollection<Review>> GetAllReviewsByItemIdAsync(int itemId)
    {
        var client = new ReviewService.ReviewServiceClient(channel);
        var reviews = new List<Review>();

        try
        {
            var request32 = new Int32Value { Value = itemId };
            var response = client.getAllReviewsByItemId(request32);
            await foreach (var item in response.ResponseStream.ReadAllAsync())
            {
                reviews.Add(item);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return reviews;
    }
}