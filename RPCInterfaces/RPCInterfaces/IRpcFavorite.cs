namespace RPCInterface.RPCImplementations;

public interface IRpcFavorite<T> : IRpcBase<Favorite>
{
    Task Delete(T element);
    Task Get(T element);
}