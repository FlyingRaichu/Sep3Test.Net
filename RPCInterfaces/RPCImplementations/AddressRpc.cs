using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using proto;

namespace RPCInterface.RPCImplementations;

public class AddressRpc : IRpcBase<Address>
{
    private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8090");


    public ICollection<Address> Elements => LoadData().Result;
    public async Task<ICollection<Address>> LoadData()
    {
         var empty = new Empty();
         var client = new AddressService.AddressServiceClient(channel);
         var addresses = new List<Address>();
         var response = client.getAllAddresses(empty);

         await foreach (var address in response.ResponseStream.ReadAllAsync())
         {
             addresses.Add(address);
         }

         return addresses;
    }

    public Task Add(Address element)
    {
        var client = new AddressService.AddressServiceClient(channel);
        try
        {
            var response = client.addAddress(element);
            Elements.Add(element);
        }
        catch (Exception e)
        {
            Console.Write(e);
        }

        return Task.CompletedTask;
    }
}