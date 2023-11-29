using System.Security.Claims;
using Domain.DTOs.User;

namespace HttpClients.Interfaces;

public interface IUserService
{
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }

    Task<User> RegisterAsync(UserCreationDto dto);
    Task LoginAsync(string userName, string password);
    Task LogoutAsync();
    Task<ClaimsPrincipal> GetAuthAsync();
    
}