using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using proto;

namespace RPCInterface.RPCImplementations;

public class OrderItemRpc : IRpcBase<OrderItem>
{
    private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8090");

    public ICollection<OrderItem> Elements => LoadData().Result;
    
    public async Task<ICollection<OrderItem>> LoadData()
    {
        var empty = new Empty();
        var client = new OrderItemService.OrderItemServiceClient(channel);
        var orderItems = new List<OrderItem>();
        var response = client.getAllOrderItems(empty);

        await foreach (var orderItem in response.ResponseStream.ReadAllAsync())
        {
            orderItems.Add(orderItem);
        }

        return orderItems;
    }

    public Task Add(OrderItem element)
    {
        var client = new OrderItemService.OrderItemServiceClient(channel);
        try
        {
            var response = client.addOrderItem(element);
            Elements.Add(element);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }

    public Task<OrderItem> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}