namespace Domain.DTOs.User;

public class UserCreationDto
{
    public string Username { get; }
    public string Password { get; set; }
    public string Email { get; }
    public string Role { get; }

    public UserCreationDto(string username, string password, string email, string role)
    {
        Username = username;
        Password = password;
        Email = email;
        Role = role;
    }
}