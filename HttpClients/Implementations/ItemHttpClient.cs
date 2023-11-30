using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs.Item;
using HttpClients.Interfaces;

namespace HttpClients.Implementations;

public class ItemHttpClient : IItemService
{
    private readonly HttpClient client;

    public ItemHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<ICollection<Item>> GetItemsAsync(string? title, string? description,
        double? price, string? manufacturer,
        int? stock, List<int>? tags)
    {
        var query = ConstructQuery(title, description, price, manufacturer, stock, tags);

        var response = await client.GetAsync("/Items" + query);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var items = JsonSerializer.Deserialize<List<Item>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        var jsonDocument = JsonDocument.Parse(content);

        foreach (var item in items)
        {
            // Manually add tags to each item
            var tagsJson = jsonDocument.RootElement
                .EnumerateArray()
                .Where(j => j.GetProperty("id").GetInt32() == item.Id)
                .Select(j => j.GetProperty("tags"));

            foreach (var tagArray in tagsJson)
            {
                item.Tags.AddRange(tagArray.EnumerateArray().Select(tag => tag.GetInt32()));
            }
        }

        return items;
    }

    public async Task<Item> CreateAsync(ItemCreationDto dto)
    {
        var response = await client.PostAsJsonAsync("/Items", dto);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var item = JsonSerializer.Deserialize<Item>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return item;
    }

    public async Task UpdateAsync(ItemUpdateDto dto)
    {
        var response = await client.PatchAsJsonAsync("/items", dto);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var response = await client.DeleteAsync($"/items/{id}");

        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<Item> GetByIdAsync(int id)
    {
        var response = await client.GetAsync($"/items/{id}");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var item = JsonSerializer.Deserialize<Item>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return item;
    }

    private static string ConstructQuery(string? title, string? description, double? price, string? manufacturer, int? stock,
        List<int>? tags)
    {
        var query = "";

        if (!string.IsNullOrEmpty(title))
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"title={title}";
        }

        if (!string.IsNullOrEmpty(description))
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"description={description}";
        }

        if (price != null)
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"price={price}";
        }

        if (!string.IsNullOrEmpty(manufacturer))
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"manufacturer={manufacturer}";
        }

        if (stock != null)
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"stock={stock}";
        }

        if (tags == null || !tags.Any()) return query;
        foreach (var i in tags)
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"tags={i}";
        }
        return query;
    }
}