namespace RPCInterface.RPCInterfaces;

public interface IRpcFavorite<T> : IRpcBase<Favorite>
{
    Task Delete(T element);
    Task<Favorite> Get(T element);
}