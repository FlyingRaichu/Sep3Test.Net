using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs.Item;

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

        var items = JsonSerializer.Deserialize<ICollection<Item>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

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

        Item item = JsonSerializer.Deserialize<Item>(content, new JsonSerializerOptions
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
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        Item item = JsonSerializer.Deserialize<Item>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return item;
    }

    private string ConstructQuery(string? title, string? description, double? price, string? manufacturer, int? stock,
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

        if (tags != null && tags.Any())
        {
            foreach (var i in tags)
            {
                query += string.IsNullOrEmpty(query) ? "?" : "&";
                query += $"tags={i}";
            }
        }

        return query;
    }
}