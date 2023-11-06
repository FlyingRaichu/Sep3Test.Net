using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using DataHandling.DAOs;
using RPCInterface.RPCImplementations;
using Via.Sep4.Protobuf;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRpcBase<Item>, ItemRpc>();
builder.Services.AddScoped<IRpcBase<User>, UserRpc>();
builder.Services.AddScoped<IItemDao, ItemDao>();
builder.Services.AddScoped<IItemLogic, ItemLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();