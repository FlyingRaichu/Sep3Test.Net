using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.DTOs.Order;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetAsync([FromQuery] string? orderFullName,
        [FromQuery] int? postalCode, [FromQuery] string? address, [FromQuery] string? city,
        [FromQuery] long? phoneNumber, [FromQuery] string? status, [FromQuery] string? date)
    {
        try
        {
            SearchOrderParametersDto parametersDto =
                new(orderFullName, postalCode, address, city, phoneNumber, status, date);
            var orders = await logic.GetAsync(parametersDto);
            return Ok(orders);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Order>> GetByIdAsync([FromRoute] int id)
    {
        try
        {
            var order = await logic.GetByIdAsync(id);
            return Ok(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<Order>> CreateAsync([FromBody] OrderCreationDto dto)
    {
        try
        {
            Order created = await logic.CreateAsync(dto);
            return Created($"/orders/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPatch]
    public async Task<ActionResult<Order>> UpdateAsync(OrderUpdateDto dto)
    {
        try
        {
            await logic.UpdateAsync(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Order>> DeleteASync([FromRoute]int id)
    {
        try
        {
            await logic.DeleteAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    //todo preaty sure this aint right
    [HttpDelete("orderItem/{id:int}")]
    public async Task<ActionResult<Order>> DeleteItemInOrderASync([FromRoute]int id)
    {
        try
        {
            await logic.DeleteAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
}