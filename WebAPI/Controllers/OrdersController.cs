using Application.LogicInterfaces;
using Domain.DTOs.Order;
using Microsoft.AspNetCore.Mvc;
using proto;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderLogic logic;

    public OrdersController(IOrderLogic logic)
    {
        this.logic = logic;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateAsync([FromBody] OrderCreationDto dto)
    {
        try
        {
            Order created = await logic.CreateAsync(dto);
            return Created($"/orders/{created.Id}", created);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}