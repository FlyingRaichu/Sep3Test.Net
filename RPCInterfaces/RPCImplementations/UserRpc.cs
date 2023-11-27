using Domain.DTOs;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Via.Sep4.Protobuf;

namespace RPCInterface.RPCImplementations;

public class UserRpc : IRpcBase<User>
{
    private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8090");


    // public User GetUser(int request)
    // {
    //     var request32 = new Int32Value { Value = request };
    //
    //     return new UserService.UserServiceClient(channel).getUser(request32);
    // }

    // public User UsernameContains(SearchUserParametersDto searchUserParametersDto)
    // {
    //     //TODO We need to ask if this is the proper way to do stuff, because it seems a bit suspicious to have to make different methods for each filter result, but it's equally suspicious to have to pull the entire list every time we want to filter
    //     var StringValue = new StringValue { Value = searchUserParametersDto.UsernameContains};
    //
    //     return new UserService.UserServiceClient(channel).usernameContains(StringValue);
    // }


    public ICollection<User> Elements { get; }

    public Task<ICollection<User>> LoadData()
    {
        throw new NotImplementedException();
    }

    public Task Add(User user)
    {
        throw new NotImplementedException();
    }

    public Task SaveChanges()
    {
        throw new NotImplementedException();
    }
    
}