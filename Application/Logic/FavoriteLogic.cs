using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;

namespace Application.Logic;

public class FavoriteLogic : IFavoriteLogic
{
    private readonly IFavoriteDao favDao;

    public FavoriteLogic(IFavoriteDao favDao)
    {
        this.favDao = favDao;
    }

    public async Task<Favorite> CreateAsync(FavoriteDto dto)
    {
        var fav = new Favorite
        {
            UserId = dto.UserId,
            ItemId = dto.ItemId
        };
        var created = await favDao.CreateAsync(fav);
        return created;
    }

    public async Task<Favorite> GetAsync(FavoriteDto dto)
    {
        var fav = new Favorite
        {
            UserId = dto.UserId,
            ItemId = dto.ItemId
        };
        var fetched = await favDao.GetAsync(fav);
        return fetched;
    }

    public async Task<Favorite> DeleteAsync(FavoriteDto dto)
    {
        var fav = new Favorite
        {
            UserId = dto.UserId,
            ItemId = dto.ItemId
        };
        var removed = await favDao.DeleteAsync(fav);
        return removed;
    }
}