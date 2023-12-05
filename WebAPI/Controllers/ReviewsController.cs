using Application.LogicInterfaces;
using Domain.DTOs.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewLogic logic;

    public ReviewsController(IReviewLogic logic)
    {
        this.logic = logic;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Review>> GetByIdAsync([FromRoute] int id)
    {
        try
        {
            var review = await logic.GetByIdAsync(id);
            return Ok(review);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Review>> CreateAsync([FromBody] ReviewCreationDto dto)
    {
        try
        {
            Review created = await logic.CreateAsync(dto);
            return Created($"/reviews/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, new { message = "Internal Server Error" });

        }
    }
    
    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<ActionResult<Review>> DeleteASync([FromRoute]int id)
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

    [HttpGet("getAllWithId")]
    public async Task<ActionResult<ICollection<Review>>> GetAllWithId([FromQuery] List<int> ids)
    {
        try
        {
            var reviews = await logic.GetAllWithIdAsync(ids);
            return Ok(reviews);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<ICollection<Review>>> GetAllReviewsByItemIdAsync([FromQuery] int itemId)
    {
        try
        {
            var reviews = await logic.GetAllReviewsByItemIdAsync(itemId);
            return Ok(reviews);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}