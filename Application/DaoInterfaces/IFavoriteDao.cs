namespace Application.DaoInterfaces;

public interface IFavoriteDao
{
    Task<Favorite> CreateAsync(Favorite fav);
    Task<Favorite> GetAsync(Favorite fav);
    Task<Favorite> DeleteAsync(Favorite fav);
}