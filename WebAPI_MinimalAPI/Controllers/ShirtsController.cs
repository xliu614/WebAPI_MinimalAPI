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
            return Ok("Reading all the shirts");
        }
        //mapping from rount to input props
        //[HttpGet("{id}/{color}")]
        //the following is to use querystring to input color, also it can be input from Header
        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public ActionResult<Shirt> GetShirtById(int id, [FromQuery(Name = nameof(color))] string? color) {
            //if (id <= 0)
            //    return BadRequest($"The input shirId {id} should be larger than 0.");

            //var shirt = ShirtRepository.GetShirtByid(id);
            //if (shirt == null)
            //    return NotFound();

            return Ok(ShirtRepository.GetShirtByid(id));
        }
        /// <summary>
        /// FromBody raw/FromForm with key value pair, here Shirt is used as model binding
        /// </summary>
        /// <param name="shirt"></param>
        /// <returns></returns>
        [HttpPost]       
        public IActionResult CreateShirt([FromForm] Shirt shirt) {
            return Ok($"Created a shirt");
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
