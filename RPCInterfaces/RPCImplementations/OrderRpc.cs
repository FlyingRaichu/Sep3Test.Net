using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using RPCInterface.RPCInterfaces;

namespace RPCInterface.RPCImplementations;

public class OrderRpc : IRpcOrder
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

    public Task Add(Order order)
    {
        var client = new OrderService.OrderServiceClient(channel);
        try
        {
            var response = client.addOrder(order);

            Elements.Add(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }

    public Task Update(Order order)
    {
        var client = new OrderService.OrderServiceClient(channel);
        try
        {
            var response = client.updateOrder(order);
            Elements.Remove(Elements.FirstOrDefault(o => o.Id == order.Id)!);
            Elements.Add(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return Task.CompletedTask;
    }

    public Task Delete(int id)
    {
        var client = new OrderService.OrderServiceClient(channel);

        try
        {
            var order = Elements.FirstOrDefault(o => o.Id == id);
            var response = client.deleteOrder(order);
            Elements.Remove(order!);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }

    public Task AddItemToOrder(OrderItem item)
    {
        var client = new OrderService.OrderServiceClient(channel);

        try
        {
            var response = client.addItemToOrder(item);
            Elements.FirstOrDefault(o => o.Id == item.OrderId)?.Items.Add(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }

    public Task UpdateItemInOrder(OrderItem item)
    {
        var client = new OrderService.OrderServiceClient(channel);

        try
        {
            var response = client.updateItemInOrder(item);
           var itemToUpdate = Elements.FirstOrDefault(o => o.Id == item.OrderId)?.Items.FirstOrDefault(i => i.Id == item.Id);
           Elements.FirstOrDefault(o => o.Id == item.OrderId)?.Items.Remove(itemToUpdate);
           Elements.FirstOrDefault(o => o.Id == item.OrderId)?.Items.Add(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }

    public Task DeleteItemFromOrder(OrderItem item)
    {
        var client = new OrderService.OrderServiceClient(channel);

        try
        {
            var response = client.deleteItemFromOrder(item);
            Elements.FirstOrDefault(o => o.Id == item.OrderId)?.Items.Remove(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }
}