using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs.User;

namespace Application.Logic;

public class UserLogic :IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.Username);
        User? existingEmail = await userDao.GetByEmailAsync(dto.Email);
        if (existing != null)
            throw new Exception("Username already taken!");
        if (existingEmail != null)
            throw new Exception("Email already exists!");
        
        ValidateUser(dto);
        var user = new User
        {
            Username = dto.Username,
            Password = dto.Password,
            Email = dto.Email,
            Role = dto.Role
        };
        var created = await userDao.CreateAsync(user);
        return created;
    }

    //when creating a user
    private void ValidateUser(UserCreationDto user)
    {
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
        {
            throw new Exception("Username and password must be filled out.");
        }

        if (!user.Email.Contains('@'))
        {
            throw new Exception("Insert valid email");
        }

        if (user.Username.Length is < 3 or > 20)
        {
            throw new Exception("Username must be at least 3 characters or less then 20");
        }
        
        //todo maybe remove later
        if (!string.Equals(user.Role, "user"))
        {
            throw new Exception("Trying to access higher security level");
        }
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        User? user = await userDao.GetByIdAsync(id);
        if (user == null)
        {
            throw new Exception($"User with Id {id} does not exist.");
        }

        return user;
    }

    
    //when logging in
    public Task<User> ValidateUser(UserValidationDto dto)
    {
        return userDao.ValidateUser(dto.Username, dto.Password);
    }
}