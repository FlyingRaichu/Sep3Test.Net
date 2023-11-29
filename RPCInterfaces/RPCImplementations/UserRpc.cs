using Domain.DTOs;
using Domain.DTOs.User;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using RPCInterface.RPCInterfaces;


namespace RPCInterface.RPCImplementations;

public class UserRpc : IRpcBase<User>
{
    private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8090");

    public ICollection<User> Elements => LoadData().Result;

    public async Task<ICollection<User>> LoadData()
    {
        var empty = new Empty();
        var client = new UserService.UserServiceClient(channel);
        var users = new List<User>();
        var response = client.getAllUsers(empty);

        await foreach (var user in response.ResponseStream.ReadAllAsync())
        {
            users.Add(user);
        }

        return users;
    }

    public User GetUser(int request)
    {
        var request32 = new Int32Value { Value = request };
    
        return new UserService.UserServiceClient(channel).getUser(request32);
    }

    public User UsernameContains(SearchUserParametersDto searchUserParametersDto)
    {
        // //TODO We need to ask if this is the proper way to do stuff, because it seems a bit suspicious to have to make different methods for each filter result, but it's equally suspicious to have to pull the entire list every time we want to filter
        // var StringValue = new StringValue { Value = searchUserParametersDto.UsernameContains};
        //
        // return new UserService.UserServiceClient(channel).usernameContains(StringValue);
        throw new NotImplementedException();
    }
    
    
    public Task Add(User user)
    {
        var client = new UserService.UserServiceClient(channel);
        try
        {
            var response = client.addUser(user);
            Elements.Add(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Task.CompletedTask;
    }

    public Task Update(User user)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task SaveChanges()
    {
        throw new NotImplementedException();
    }
}