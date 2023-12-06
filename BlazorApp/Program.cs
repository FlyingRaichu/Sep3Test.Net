using BlazorApp.Auth;
using BlazorApp.Pages.Services;
using Domain.Auth;
using BlazorApp.Service;
using HttpClients.Implementations;
using HttpClients.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddSingleton<NavService>();
builder.Services.AddSingleton<HttpClient>(new HttpClient
{
    BaseAddress = new Uri("https://localhost:7248/swagger/index.html")
});
builder.Services.AddScoped<IItemService, ItemHttpClient>();
builder.Services.AddScoped<IUserService, UserHttpClient>();
builder.Services.AddScoped<ITagService, TagHttpClient>();
builder.Services.AddScoped<IOrderService, OrderHttpClient>();
builder.Services.AddScoped<IFavoriteService, FavoriteHttpClient>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<NavigationService>();
builder.Services.AddScoped<ShoppingCartService>();

AuthorizationPolicies.AddPolicies(builder.Services);
builder.Services.AddSingleton<NavService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();