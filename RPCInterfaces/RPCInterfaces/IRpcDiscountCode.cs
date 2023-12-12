namespace RPCInterface.RPCInterfaces;

public interface IRpcDiscountCode<T>
{
    ICollection<T> Elements { get;}
    Task<ICollection<T>> LoadData();
    Task Add(T element);
    Task Delete(int id);
}