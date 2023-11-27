using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using proto;

namespace RPCInterface.RPCImplementations;

public class FullNameRpc : IRpcBase<FullName>
{
    private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8090");


    public ICollection<FullName> Elements => LoadData().Result;
    
    public async Task<ICollection<FullName>> LoadData()
    {
        var empty = new Empty();
        var client = new FullNameService.FullNameServiceClient(channel);
        var fullNames = new List<FullName>();
        var response = client.getAllFullNames(empty);


        await foreach (var fullName in response.ResponseStream.ReadAllAsync())
        {
            fullNames.Add(fullName);
        }

        return fullNames;
    }

    public Task Add(FullName element)
    {
        var client = new FullNameService.FullNameServiceClient(channel);
        try
        {
            var response = client.addFullName(element);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }

    public async Task<FullName?> GetByIdAsync(int id)
    {
        FullName? response = null;
        var client = new FullNameService.FullNameServiceClient(channel);
        try
        {
            var int32 = new Google.Protobuf.WellKnownTypes.Int32Value
            {
                Value = id
            };
            response = client.getFullName(int32);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return response;
    }
}