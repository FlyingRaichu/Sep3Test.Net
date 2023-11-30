using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
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

    public async Task<Favorite> CreateAsync(FavoriteDto dto, string? token)
    {
        //prep request
        var request = new HttpRequestMessage(HttpMethod.Post, "/Favorites/Create");
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Add("Authorization", "Bearer " + token);
        }
        var jsonDto = JsonSerializer.Serialize(dto);
        request.Content = new StringContent(jsonDto, Encoding.UTF8, "application/json");
        
        //send and receive
        var response = await client.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            throw new Exception(content);
        }

        Favorite fav = JsonSerializer.Deserialize<Favorite>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return fav;
    }

    public async Task<Favorite?> GetAsync(FavoriteDto dto, string? token)
    {
        //prep request
        var requestUri = $"Favorites/Get?userId={dto.UserId}&itemId={dto.ItemId}";
        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Add("Authorization", "Bearer " + token);
        }

        //send and receive
        var response = await client.SendAsync(request);
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            throw new Exception(content);
        }

        var favorite = JsonSerializer.Deserialize<Favorite>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return favorite;
    }

    public Task<Favorite?> GetAllAsync(int userId, string? token)
    {
        throw new NotImplementedException();
    }

    public async Task<Favorite> DeleteAsync(FavoriteDto dto, string? token)
    {
        //prep request
        var url = "/Favorites/Delete";
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        var jsonDto = JsonSerializer.Serialize(dto);
        request.Content = new StringContent(jsonDto, Encoding.UTF8, "application/json");
        
        //send and receive
        var response = await client.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            throw new Exception(content);
        }

        Favorite deleted = JsonSerializer.Deserialize<Favorite>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return deleted;
    }
}