namespace RPCInterface.RPCImplementations;

public interface IRpcBase<T>
{
    Task<ICollection<T>> LoadData();
    Task Add(T element);
}