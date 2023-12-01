using Application.DaoInterfaces;
using RPCInterface.RPCImplementations;

namespace DataHandling.DAOs;

public class FavoriteDao : IFavoriteDao
{
    private readonly IRpcFavorite<Favorite> context;

    public FavoriteDao(IRpcFavorite<Favorite> context)
    {
        this.context = context;
    }
    
    public Task<Favorite> CreateAsync(Favorite favorite)
    {
        context.Add(favorite);
        return Task.FromResult(favorite);
    }

    public Task<Favorite> GetAsync(Favorite fav)
    {
        var favorite = context.Get(fav);
        return Task.FromResult(fav);
    }

    public Task<Favorite> DeleteAsync(Favorite fav)
    {
        var favorite = context.Delete(fav);
        return Task.FromResult(fav);
    }
}