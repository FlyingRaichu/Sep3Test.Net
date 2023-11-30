using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using RPCInterface.RPCInterfaces;

namespace RPCInterface.RPCImplementations;

public class TagRpc : ITagRpc
{
    private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8090");
    public ICollection<Tag> Elements => LoadData().Result;
    
    
    public async Task<ICollection<Tag>> LoadData()
    {
        var empty = new Empty();
        var client = new TagService.TagServiceClient(channel);
        var tags = new List<Tag>();
        var response = client.getAllTags(empty);


        await foreach (var item in response.ResponseStream.ReadAllAsync())
        {
            tags.Add(item);
        }

        return tags;
    }

    public Task Add(Tag tag)
    {
        var client = new TagService.TagServiceClient(channel);
        try
        {
            var response = client.addTag(tag);
            Elements.Add(tag);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }

    public Task Update(Tag tag)
    {
        var client = new TagService.TagServiceClient(channel);
        try
        {
            var response = client.updateTag(tag);
            Elements.Remove(Elements.FirstOrDefault(i => i.Id == tag.Id)!);
            Elements.Add(tag);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }

    public Task Delete(int id)
    {
        var client = new TagService.TagServiceClient(channel);

        try
        {
            Tag? tag = Elements.FirstOrDefault(i => i.Id == id);
            var response = client.deleteTag(tag);
            Elements.Remove(tag);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }

    public async Task<ICollection<Tag>> GetAllWithId(IntListRequest request)
    {
        var client = new TagService.TagServiceClient(channel);
        var tags = new List<Tag>();

        try
        {
            var response = client.getAllWithId(request);
            
            await foreach (var item in response.ResponseStream.ReadAllAsync())
            {
                tags.Add(item);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return tags;
    }
}