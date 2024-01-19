using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_MinimalAPI.Filters;
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
        public IActionResult UpdateShirt(int id) {
            return Ok($"Updated the shirt with ID: {id}");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteShirt(int id) {
            return Ok($"Deleted the shirt with ID: {id}");
        }
    }
}
