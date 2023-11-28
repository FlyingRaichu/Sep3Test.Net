using Domain.DTOs;

namespace HttpClients.Implementations;

public interface IFavoriteService
{
    Task<Favorite> CreateAsync(FavoriteDto dto);
    Task<Favorite> GetAsync(FavoriteDto dto);
    Task<Favorite> DeleteAsync(FavoriteDto dto);
}