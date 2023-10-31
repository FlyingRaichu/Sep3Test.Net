using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using RPCInterface.RPCImplementations;
using Via.Sep4.Protobuf;

namespace RPCInterface.RPCImplementations;

public class ItemRpc : IRpcBase<Item>
{
    private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8090");

    public ICollection<Item> Items => LoadData().Result;

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
            var response = client.addItem(item);
            Items.Add(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }
}