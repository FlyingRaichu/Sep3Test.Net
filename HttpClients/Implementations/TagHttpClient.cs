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

    public Task<Tag> CreateAsync(TagCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TagUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Tag> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}