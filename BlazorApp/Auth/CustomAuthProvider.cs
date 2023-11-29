using System.Security.Claims;
using HttpClients.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorApp.Auth;

public class CustomAuthProvider : AuthenticationStateProvider
{
    private readonly IUserService authService;

    public CustomAuthProvider(IUserService authService)
    {
        this.authService = authService;
        authService.OnAuthStateChanged += AuthStateChanged;
    }
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = await authService.GetAuthAsync();
        
        return new AuthenticationState(principal);
    }
    
    private void AuthStateChanged(ClaimsPrincipal principal)
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(principal)
            )
        );
    }
}