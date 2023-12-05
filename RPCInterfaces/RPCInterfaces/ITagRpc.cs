namespace RPCInterface.RPCInterfaces;

public interface ITagRpc : IRpcBase<Tag>
{
    Task<ICollection<Tag>> GetAllWithId(IntListRequest request);
}