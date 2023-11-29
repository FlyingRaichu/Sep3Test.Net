using Application.LogicInterfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class FavoritesController : ControllerBase
{
    private readonly IFavoriteLogic favLogic;

    public FavoritesController(IFavoriteLogic favLogic)
    {
        this.favLogic = favLogic;
    }
    
    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> CreateAsync([FromBody]FavoriteDto dto)
    {
        try
        {
            var result = await favLogic.CreateAsync(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500, new { message = "Internal Server Error" });
        }
    }
    
    [HttpDelete]
    [Route("Delete")]
    public async Task<ActionResult> DeleteFavoriteAsync([FromBody] FavoriteDto dto)
    {
        try
        {
            var result = await favLogic.DeleteAsync(dto);
            
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500, new { message = "Internal Server Error" });
        }
    }
    
    [HttpGet]
    [Route("Get")]
    public async Task<ActionResult> GetFavoriteAsync([FromQuery] int userId, [FromQuery] int itemId)
    {
        try
        {
            FavoriteDto dto = new FavoriteDto(userId, itemId);
            var result = await favLogic.GetAsync(dto);
            
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(new { message = "Favorite not found" });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500, new { message = "Internal Server Error" });
        }
    }
}