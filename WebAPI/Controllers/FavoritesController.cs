using Application.LogicInterfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FavoritesController : ControllerBase
{
    private readonly IFavoriteLogic favLogic;

    public FavoritesController(IFavoriteLogic favLogic)
    {
        this.favLogic = favLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody]FavoriteDto dto)
    {
        var result = await favLogic.CreateFavoriteAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }
}