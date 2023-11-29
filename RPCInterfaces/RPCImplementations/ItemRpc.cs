using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using RPCInterface.RPCInterfaces;

namespace RPCInterface.RPCImplementations;

public class ItemRpc : IRpcBase<Item>
{
    private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8090");
    
    public ICollection<Item> Elements =>  LoadData().Result;

    public async Task<ICollection<Item>> LoadData()
    {
        var empty = new Empty();
        var client = new ItemService.ItemServiceClient(channel);
        var items = new List<Item>();
        var response = client.getAllItems(empty);


        await foreach (var item in response.ResponseStream.ReadAllAsync())
        {
            items.Add(item);
        }

        return items;
    }

    public Task Add(Item item)
    {
        var client = new ItemService.ItemServiceClient(channel);
        try
        {
            Console.WriteLine($"In RPC: {item.Manufacturer}");
            var response = client.addItem(item);
            Console.WriteLine($"In RPC: {item.Manufacturer}");
            Elements.Add(item);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }

    public Task Update(Item item)
    {
        var client = new ItemService.ItemServiceClient(channel);
        try
        {
            var response = client.updateItem(item);
            Elements.Remove(Elements.FirstOrDefault(i => i.Id == item.Id)!);
            Elements.Add(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }

    public Task Delete(int id)
    {
        var client = new ItemService.ItemServiceClient(channel);

        try
        {
            Item? item = Elements.FirstOrDefault(i => i.Id == id);
            var response = client.deleteItem(item);
            Elements.Remove(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }
}