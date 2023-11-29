namespace RPCInterface.RPCInterfaces;

public interface IRpcBase<T>
{
    ICollection<T> Elements { get;}
    Task<ICollection<T>> LoadData();
    Task Add(T element);
    Task Update(T element);
    Task Delete(int id);
}