using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IFavoriteLogic
{
    Task<Favorite> CreateAsync(FavoriteDto dto);
    Task<Favorite> GetAsync(FavoriteDto dto);
    Task<Favorite> DeleteAsync(FavoriteDto dto);
}