namespace RPCInterface.RPCImplementations;

public interface IRpcBase<T>
{
    ICollection<T> Elements { get;}
    Task<ICollection<T>> LoadData();
    Task Add(T element);
    Task<T> GetByIdAsync(int id);
}