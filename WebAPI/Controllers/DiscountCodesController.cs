using System;
using System.Threading.Tasks;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.DTOs.DiscountCode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class DiscountCodesController : ControllerBase
    {
        private readonly IDiscountCodeLogic discountCodeLogic;

        public DiscountCodesController(IDiscountCodeLogic discountCodeLogic)
        {
            this.discountCodeLogic = discountCodeLogic;
        }

        [HttpPost]
        public async Task<ActionResult<DiscountCode>> CreateAsync([FromBody] DiscountCodeDto dto)
        {
            try
            {
                var result = await discountCodeLogic.CreateAsync(dto);
                return Created($"/discountCodes/{result.Id}", result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        [HttpDelete("{id:int}")]


        public async Task<ActionResult> DeleteDiscountCodeAsync([FromRoute] int id)
        {
            try
            {
                await discountCodeLogic.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscountCode>>> GetAsync([FromQuery] string? code,
            [FromQuery] int? discountPercentage)
        {
            try
            {
                SearchDiscountParametersDto parameters = new(code, discountPercentage);
                var discountCodes = await discountCodeLogic.GetAsync(parameters);
                return Ok(discountCodes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }

        }
    }

       
    
