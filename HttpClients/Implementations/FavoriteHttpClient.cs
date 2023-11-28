using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using HttpClients.Implementations;

namespace HttpClients.Interfaces;

public class FavoriteHttpClient : IFavoriteService
{
    private readonly HttpClient client;

    public FavoriteHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<Favorite> CreateAsync(FavoriteDto dto)
    {
        var response = await client.PostAsJsonAsync("/Favorites", dto);
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

    public async Task<Favorite> GetAsync(FavoriteDto dto)
    {
        HttpResponseMessage response = await client.GetAsync("/Favorites");
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

    public Task<Favorite> DeleteAsync(FavoriteDto missing_name)
    {
        throw new NotImplementedException();
    }
}