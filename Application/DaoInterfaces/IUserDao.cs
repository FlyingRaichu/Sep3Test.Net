namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByUsernameAsync(string dtoUsername);
    Task<User?> GetByEmailAsync(string dtoEmail);
    Task<User> ValidateUser(string dtoUsername, string dtoPassword);
}