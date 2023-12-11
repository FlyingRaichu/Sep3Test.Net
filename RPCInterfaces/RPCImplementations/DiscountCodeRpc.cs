using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using RPCInterface.RPCInterfaces;

namespace RPCInterface.RPCImplementations;

public class DiscountCodeRpc : IRpcDiscountCode<DiscountCode>
{
    private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8090");
    public ICollection<DiscountCode> Elements => LoadData().Result;
    
    public async Task<ICollection<DiscountCode>> LoadData()
    {
        var empty = new Empty();
        var client = new DiscountCodeService.DiscountCodeServiceClient(channel);
        var discountCodes = new List<DiscountCode>();
        var response = client.getAllDiscountCodes(empty);


        await foreach (var discountCode in response.ResponseStream.ReadAllAsync())
        {
            discountCodes.Add(discountCode);
        }

        return discountCodes;
    }

    public Task Add(DiscountCode element)
    {
        var client = new DiscountCodeService.DiscountCodeServiceClient(channel);
        try
        {
            var response = client.addDiscountCode(element);
            Elements.Add(element);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
        }

        return Task.CompletedTask;
    }
    

    public Task Delete(int id)
    {
        var client = new DiscountCodeService.DiscountCodeServiceClient(channel);

        try
        {
            var discountCode = Elements.FirstOrDefault(i => i.Id == id);
            var response = client.deleteDiscountCode(discountCode);
            Elements.Remove(discountCode!);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }

   

    
}