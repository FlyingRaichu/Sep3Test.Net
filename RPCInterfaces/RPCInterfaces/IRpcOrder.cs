namespace RPCInterface.RPCInterfaces;

public interface IRpcOrder : IRpcBase<Order>
{
    Task AddItemToOrder(OrderItem item);
    Task UpdateItemInOrder(OrderItem item);
    Task DeleteItemFromOrder(OrderItem item);
}