using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using Domain.DTOs.User;
using HttpClients.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace HttpClients.Implementations;

public class UserHttpClient : IUserService
{
    private readonly HttpClient client;
    public static string? Jwt { get; private set; }
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null;

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
    }

    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        string payload = jwt.Split('.')[1];
        byte[] jsonBytes = ParseBase64WithoutPadding(payload);
        Dictionary<string, object>? keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }
    
    private static ClaimsPrincipal CreateClaimsPrincipal()
    {
        if (string.IsNullOrEmpty(Jwt))
        {
            return new ClaimsPrincipal();
        }

        IEnumerable<Claim> claims = ParseClaimsFromJwt(Jwt);
    
        ClaimsIdentity identity = new(claims, "jwt");

        ClaimsPrincipal principal = new(identity);
        return principal;
    }


    public async Task<User> RegisterAsync(UserCreationDto dto)
    {
        try
        {
            // Hash the password before sending it to the server
            dto.Password = HashPassword(dto.Password);

            HttpResponseMessage response = await client.PostAsJsonAsync("/users", dto);
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        }
        catch (HttpRequestException ex)
        {
            // Log the exception or handle it based on your application's requirements.
            throw new Exception("Error during user registration.", ex);
        }
    }

    public async Task LoginAsync(string userName, string password)
    {
        try
        {
            // Hash the password before sending it to the server
            password = HashPassword(password);

            UserValidationDto dto = new(userName, password);

            HttpResponseMessage response = await client.PostAsJsonAsync("/users/login", dto);
            response.EnsureSuccessStatusCode();

            Jwt = await response.Content.ReadAsStringAsync();

            var principal = CreateClaimsPrincipal();
            Console.WriteLine($"{dto.Username}, {password}"); // Note: Logging the hashed password for demonstration purposes
            OnAuthStateChanged.Invoke(principal);
        }
        catch (HttpRequestException ex)
        {
            // Log the exception or handle it based on your application's requirements.
            throw new Exception("Error during user login.", ex);
        }
    }

    public Task LogoutAsync()
    {
        Jwt = null;
        ClaimsPrincipal principal = new();
        OnAuthStateChanged.Invoke(principal);
        return Task.CompletedTask;
    }

    public Task<ClaimsPrincipal> GetAuthAsync()
    {
        ClaimsPrincipal principal = CreateClaimsPrincipal();
        return Task.FromResult(principal);
    }
    private static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
    
}