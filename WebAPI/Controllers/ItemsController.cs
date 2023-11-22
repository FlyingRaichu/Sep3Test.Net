using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.DTOs.Item;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using proto;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemLogic logic;

    public ItemsController(IItemLogic logic)
    {
        this.logic = logic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> GetAsync([FromQuery] string? title,
        [FromQuery] string? description, [FromQuery] double? price)
    {
        try
        {
            SearchItemParametersDto parameters = new(title, description, price);
            var items = await logic.GetAsync(parameters);
            return Ok(items);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Item>> CreateAsync([FromBody] ItemCreationDto dto)
    {
        try
        {
            Item created = await logic.CreateAsync(dto);
            return Created($"/items/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}