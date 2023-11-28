using Application.DaoInterfaces;
using RPCInterface.RPCImplementations;

namespace DataHandling.DAOs;

public class FavoriteDao : IFavoriteDao
{
    private readonly IRpcBase<Favorite> context;

    public FavoriteDao(IRpcBase<Favorite> context)
    {
        this.context = context;
    }
    
    public Task<Favorite> CreateAsync(Favorite favorite)
    {
        int id = 1;
        if (context.Elements.Any())
        {
            id = context.Elements.Max(i => i.ItemId);
            id++;
        }

        favorite.ItemId = id;

        context.Add(favorite);
        return Task.FromResult(favorite);
    }

    public Task<Favorite> GetAsync(Favorite fav)
    {
        var favorite = context.Elements.SingleOrDefault(f => f.ItemId == fav.ItemId);
    
        return Task.FromResult(favorite);
    }

    public Task<Favorite> DeleteAsync(Favorite fav)
    {
        throw new NotImplementedException();
    }
}