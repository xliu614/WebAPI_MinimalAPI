﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_MinimalAPI.Filters.ActionFilters;
using WebAPI_MinimalAPI.Filters.ExceptionFilters;
using WebAPI_MinimalAPI.Models;
using WebAPI_MinimalAPI.Models.Repositories;

namespace WebAPI_MinimalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetShirts() {
            return Ok(ShirtRepository.GetShirts());
        }
        //mapping from rount to input props
        //[HttpGet("{id}/{color}")]
        //the following is to use querystring to input color, also it can be input from Header
        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public ActionResult<Shirt> GetShirtById(int id, [FromQuery(Name = nameof(color))] string? color) {
            return Ok(ShirtRepository.GetShirtByid(id));
        }
        /// <summary>
        /// FromBody raw/FromForm with key value pair, here Shirt is used as model binding
        /// </summary>
        /// <param name="shirt"></param>
        /// <returns></returns>
        [HttpPost]
        [Shirt_ValidateCreateShirtPropsFilter]
        public IActionResult CreateShirt([FromBody] Shirt shirt) {
            
            ShirtRepository.AddShirt(shirt);
            return CreatedAtAction(nameof(GetShirtById),new { id = shirt.ShirtId }, shirt);
        }

        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_UpdateExceptionFilter]
        public IActionResult UpdateShirt(int id, [FromBody] Shirt shirt) {
            //using try catch block here, because there's possibility that when shirt's updated, it's already been removed
            ShirtRepository.UpdateShirt(shirt);            

            return NoContent();
        }
        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult DeleteShirt(int id) {

            var shirt = ShirtRepository.GetShirtByid(id);
            ShirtRepository.RemoveShirt(id);
            return Ok(shirt);
        }
    }
}
