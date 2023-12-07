using System.Net;
using System.Net.Http.Json;
using System.Text;
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
    
    public async Task<Review> CreateAsync(ReviewCreationDto dto, string token)
    {
        Console.WriteLine($"create async method: {dto.Rating}, {dto.Content}");
        var request = new HttpRequestMessage(HttpMethod.Post, "/Reviews");
        
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Add("Authorization", "Bearer " + token);
        }
        var jsonDto = JsonSerializer.Serialize(dto);
        request.Content = new StringContent(jsonDto, Encoding.UTF8, "application/json");

        var response = await client.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            Console.WriteLine(content);
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

    public async Task<ICollection<Review>> GetAllWithIdAsync(List<int> ids)
    {
        var query = BuildQuery(ids);
        var response = await client.GetAsync($"/Reviews/getAllWithId{query}");
        var content = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var reviews = JsonSerializer.Deserialize<ICollection<Review>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return reviews;
    }

    public async Task<ICollection<Review>> GetAllReviewsByItemIdAsync(int itemId)
    {
        var response = await client.GetAsync($"/reviews?itemId={itemId}");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        
        var reviews = JsonSerializer.Deserialize<ICollection<Review>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return reviews;
    }

    private string BuildQuery(List<int>? ids)
    {
        if (ids != null && ids.Any())
        {
            var query = $"?ids={ids.First()}";
            query = ids.Skip(1).Aggregate(query, (current, id) => current + $"&ids={id}");
            
            Console.WriteLine(query);
            return query;
        }

        return "?ids=999999"; 
    }
}