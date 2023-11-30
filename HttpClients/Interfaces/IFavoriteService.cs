using Domain.DTOs;

namespace HttpClients.Implementations;

public interface IFavoriteService
{
    Task<Favorite> CreateAsync(FavoriteDto dto, string? token);
    Task<Favorite?> GetAsync(FavoriteDto dto, string? token);
    Task<Favorite> DeleteAsync(FavoriteDto dto, string? token);
}