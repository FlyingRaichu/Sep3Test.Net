using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using proto;

namespace RPCInterface.RPCImplementations;

public class OrderRpc : IRpcBase<Order>
{
    private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8090");

    public ICollection<Order> Elements => LoadData().Result;
    
    public async Task<ICollection<Order>> LoadData()
    {
        var empty = new Empty();
        var client = new OrderService.OrderServiceClient(channel);
        var orders = new List<Order>();
        var response = client.getAllOrders(empty);

        await foreach (var order in response.ResponseStream.ReadAllAsync())
        {
            orders.Add(order);
        }

        return orders;
    }

    public Task Add(Order element)
    {
        var client = new OrderService.OrderServiceClient(channel);
        try
        {
            var response = client.addOrder(element);
            Elements.Add(element);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;

    }

    public Task<Order> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}