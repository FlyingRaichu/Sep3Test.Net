using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;

namespace RPCInterface.RPCImplementations;

public class FavoriteRpc : IRpcBase<Favorite>
{
    private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8090");
    public ICollection<Favorite> Elements { get; }

    public Task<ICollection<Favorite>> LoadData()
    {
        throw new NotImplementedException();
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
}