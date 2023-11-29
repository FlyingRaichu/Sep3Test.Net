using Microsoft.Extensions.DependencyInjection;

namespace Domain.Auth;

public static class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("LoggedIn", a => a.RequireAuthenticatedUser());
            
            options.AddPolicy("MustBeAdmin", a => a.RequireAuthenticatedUser().RequireClaim("Role", "admin"));

            options.AddPolicy("User", a => a.RequireAuthenticatedUser().RequireClaim("Role", "user"));
        });
    }
}