using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using RPCInterface.RPCInterfaces;

namespace RPCInterface.RPCImplementations;

public class FavoriteRpc : IRpcFavorite<Favorite>
{
    private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8090");
    public ICollection<Favorite> Elements =>  LoadData().Result;

    public Task Delete(Favorite element)
    {
        var client = new FavoriteService.FavoriteServiceClient(channel);
        try
        {
            var response = client.deleteFavorite(element);
            Elements.Remove(element);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }

    public async Task<ICollection<Favorite>> LoadData()
    {
        var empty = new Empty();
        var client = new FavoriteService.FavoriteServiceClient(channel);
        var items = new List<Favorite>();
        var response = client.getAllFavorites(empty);


        await foreach (var item in response.ResponseStream.ReadAllAsync())
        {
            items.Add(item);
        }

        return items;
    }

    public Task Add(Favorite favorite)
    {
        var client = new FavoriteService.FavoriteServiceClient(channel);
        try
        {
            var response = client.addFavorite(favorite);
            Elements.Add(favorite);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }

    public Task Get(Favorite favorite)
    {
        var client = new FavoriteService.FavoriteServiceClient(channel);
        try
        {
            var response = client.getFavorite(favorite);
            Elements.Clear();
            Elements.Add(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }
    
    public Task Update(Favorite element)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}