namespace RPCInterface.RPCImplementations;

public interface IRpcBase<T>
{
    Task<ICollection<T>> LoadData();
    Task SaveChanges();
}