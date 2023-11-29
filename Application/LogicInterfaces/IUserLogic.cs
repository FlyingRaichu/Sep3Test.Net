using Domain.DTOs.User;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto dto);
    Task<User?> GetByIdAsync(int id);
    Task<User> ValidateUser(UserValidationDto dto);
}