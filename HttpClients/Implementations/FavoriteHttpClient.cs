using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;

namespace HttpClients.Implementations;

public class FavoriteHttpClient : IFavoriteService
{
    private readonly HttpClient client;

    public FavoriteHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<Favorite> CreateAsync(FavoriteDto dto)
    {
        var response = await client.PostAsJsonAsync("/Favorites/Create", dto);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        Favorite fav = JsonSerializer.Deserialize<Favorite>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return fav;
    }

    public async Task<Favorite?> GetAsync(FavoriteDto dto)
    {
        HttpResponseMessage response = await client.GetAsync($"Favorites/Get?userId={dto.UserId}&itemId={dto.ItemId}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        
        var favorite = JsonSerializer.Deserialize<Favorite>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return favorite;
    }

    public async Task<Favorite> DeleteAsync(FavoriteDto dto)
    {
        var url = "/Favorites/Delete";

        var response = await client.PostAsJsonAsync(url, dto);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        Favorite deleted = JsonSerializer.Deserialize<Favorite>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return deleted;
    }
}