using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.DTOs.Order;
using Domain.DTOs.OrderItem;
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
            var created = await logic.CreateAsync(dto);
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

    [HttpPost]
    [Route("/orderItems")]
    public async Task<ActionResult<OrderItem>> AddItemToOrderAsync([FromBody] OrderItemCreationDto dto)
    {
        try
        {
            OrderItem created = await logic.AddItemToOrder(dto);
            return Created($"orders/orderItems/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPatch]
    [Route("/orderItems")]
    public async Task<ActionResult<OrderItem>> UpdateItemInOrderAsync(OrderItemUpdateDto dto)
    {
        try
        {
            await logic.UpdateItemInOrder(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
    [HttpDelete("/orderItem/{orderItemId:int}")]
    public async Task<ActionResult<Order>> DeleteItemInOrderASync([FromRoute]int orderItemId, int orderId)
    {
        try
        {
            var order = logic.GetByIdAsync(orderId);
            var orderItem = order.Result.Items.FirstOrDefault(oi => oi.Id == orderItemId);
            await logic.DeleteItemFromOrder(orderItem);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
}