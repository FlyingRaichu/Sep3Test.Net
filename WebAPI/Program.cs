using System.Text;
using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using DataHandling.DAOs;
using Domain.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RPCInterface.RPCImplementations;
using proto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRpcBase<Address>, AddressRpc>();
builder.Services.AddScoped<IRpcBase<FullName>, FullNameRpc>();
builder.Services.AddScoped<IRpcBase<Item>, ItemRpc>();
builder.Services.AddScoped<IRpcBase<OrderItem>, OrderItemRpc>();
builder.Services.AddScoped<IRpcBase<Order>, OrderRpc>();
builder.Services.AddScoped<IRpcBase<User>, UserRpc>();

builder.Services.AddScoped<IAddressDao, AddressDao>();
builder.Services.AddScoped<IAddressLogic, AddressLogic>();

builder.Services.AddScoped<IFullNameDao, FullNameDao>();
builder.Services.AddScoped<IFullNameLogic, FullNameLogic>();

builder.Services.AddScoped<IItemDao, ItemDao>();
builder.Services.AddScoped<IItemLogic, ItemLogic>();

builder.Services.AddScoped<IOrderItemDao, OrderItemDao>();
builder.Services.AddScoped<IOrderItemLogic, OrderItemLogic>();

builder.Services.AddScoped<IOrderDao, OrderDao>();
builder.Services.AddScoped<IOrderLogic, OrderLogic>();



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

AuthorizationPolicies.AddPolicies(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());

app.MapControllers();

app.Run();