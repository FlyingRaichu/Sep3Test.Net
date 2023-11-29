using Application.DaoInterfaces;
using RPCInterface.RPCImplementations;
using RPCInterface.RPCInterfaces;

namespace DataHandling.DAOs;

public class UserDao : IUserDao
{
    private readonly IRpcBase<User> context;

    public UserDao(IRpcBase<User> context)
    {
        this.context = context;
    }

    public Task<User> CreateAsync(User user)
    {
        int id = 1;
        if (context.Elements.Any())
        {
            id = context.Elements.Max(i => i.Id);
            id++;
        }

        user.Id = id;

        context.Add(user);
        return Task.FromResult(user);
    }

    public Task<User?> GetByIdAsync(int id)
    {
        var user = context.Elements.FirstOrDefault(i => i.Id == id);
        return Task.FromResult(user);
    }

    public async Task<User?> GetByUsernameAsync(string dtoUsername)
    {
        User? existing = context.Elements.FirstOrDefault(u => 
            u.Username.ToLower().Equals(dtoUsername.ToLower()));
        return existing;
    }

    public async Task<User?> GetByEmailAsync(string dtoEmail)
    {
        User? existing =  context.Elements.FirstOrDefault(u =>
            u.Email.Equals(dtoEmail));
        return existing;
    }

    public async Task<User> ValidateUser(string dtoUsername, string dtoPassword)
    {
        User? existingUser = context.Elements.FirstOrDefault(u => u.Username.Equals(dtoUsername));

        if (existingUser == null)
        {
            throw new Exception("User not found. Please ensure username/password is correct.");
        }

        if (!existingUser.Password.Equals(dtoPassword))
        {
            throw new Exception("User not found. Please ensure username/password is correct.");
        }

        return existingUser;
    }
}