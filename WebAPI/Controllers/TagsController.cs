using Application.LogicInterfaces;
using Domain.DTOs.Tag;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TagsController : ControllerBase
{
    private readonly ITagLogic logic;

    public TagsController(ITagLogic logic)
    {
        this.logic = logic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tag>>> GetAsync([FromQuery] string? tagName)
    {
        try
        {
            SearchTagParametersDto parameters = new(tagName);
            var tags = await logic.GetAsync(parameters);
            return Ok(tags);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Tag>> GetByIdAsync([FromRoute] int id)
    {
        try
        {
            var tag = await logic.GetByIdAsync(id);
            return Ok(tag);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("getAllWithId")]
    public async Task<ActionResult<IEnumerable<Tag>>> GetAllWithId([FromQuery] List<int> ids)
    {
        try
        {
            var tags = await logic.GetAllWithIdAsync(ids);
            return Ok(tags);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Tag>> CreateAsync([FromBody] TagCreationDto dto)
    {
        try
        {
            Console.WriteLine($"Name: {dto.Name}");
            Tag created = await logic.CreateAsync(dto);
            
            return Created($"/tags/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPatch]
    public async Task<ActionResult<Tag>> UpdateAsync(TagUpdateDto dto)
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
    public async Task<ActionResult<Tag>> DeleteASync([FromRoute]int id)
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