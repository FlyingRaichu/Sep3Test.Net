using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs.Review;
using HttpClients.Interfaces;

namespace HttpClients.Implementations;

public class ReviewHttpClient : IReviewService
{
    private readonly HttpClient client;

    public ReviewHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<Review> CreateAsync(ReviewCreationDto dto)
    {
        var response = await client.PostAsJsonAsync("/reviews", dto);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var review = JsonSerializer.Deserialize<Review>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return review;
    }

    public async Task DeleteAsync(int id)
    {
        var response = await client.DeleteAsync($"/reviews/{id}");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }

    public async Task<Review> GetByIdAsync(int id)
    {
        var response = await client.GetAsync($"/Reviews/{id}");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        Review review = JsonSerializer.Deserialize<Review>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return review;
    }

    public async Task<IEnumerable<Review>> GetAllWithIdAsync(List<int> ids)
    {
        throw new NotImplementedException();
    }
}