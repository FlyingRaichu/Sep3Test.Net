using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using HttpClients.Implementations;

namespace HttpClients.Interfaces;

public class ItemHttpClient : IItemService
{
    private readonly HttpClient client;
    
    public ItemHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<ICollection<Item>> GetPostsAsync(string? title, string? description, double? price)
    {
        var query = ConstructQuery(title, description, price);

        var response = await client.GetAsync("/Items" + query);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Item> items = JsonSerializer.Deserialize<ICollection<Item>>(content, new JsonSerializerOptions
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

    private string ConstructQuery(string? title, string? description, double? price)
    {
        string query = "";

        if (!String.IsNullOrEmpty(title))
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"title={title}";
        }

        if (!String.IsNullOrEmpty(description))
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"description={description}";
        }

        if (price != null)
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"price={price}";
        }

        return query;
    }
}