using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs.Tag;

namespace HttpClients.Implementations;

public class TagHttpClient : ITagService
{
    private readonly HttpClient client;

    public TagHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<ICollection<Tag>> GetTagsAsync(string? name)
    {
        var response = await client.GetAsync($"/tags?tagName={name}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var tags = JsonSerializer.Deserialize<ICollection<Tag>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return tags;
    }

    public async Task<Tag> CreateAsync(TagCreationDto dto)
    {
        var response = await client.PostAsJsonAsync("/tags", dto);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var tag = JsonSerializer.Deserialize<Tag>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return tag;
    }

    public async Task UpdateAsync(TagUpdateDto dto)
    {
        var response = await client.PatchAsJsonAsync("/tags", dto);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var response = await client.DeleteAsync($"/tags/{id}");

        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<Tag> GetByIdAsync(int id)
    {
        var response = await client.GetAsync($"/tags/{id}");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var tag = JsonSerializer.Deserialize<Tag>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return tag;
    }

    public async Task<ICollection<Tag>> GetAllWithId(List<int> ids)
    {
        var query = BuildQuery(ids);
        var response = await client.GetAsync($"/tags/getAllWithId{query}");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        
        var tags = JsonSerializer.Deserialize<ICollection<Tag>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return tags;
    }

    private static string BuildQuery(IReadOnlyCollection<int>? ids)
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