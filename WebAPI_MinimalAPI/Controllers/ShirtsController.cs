using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_MinimalAPI.Models;

namespace WebAPI_MinimalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        private readonly List<Shirt> shirts = new List<Shirt>()
        {
           new Shirt {ShirtId=1, Brand = "V Brand", Color ="Yellow", Gender="women", Price = 30, Size=6 },
           new Shirt {ShirtId=2, Brand = "V Brand", Color ="Blue", Gender="women", Price = 30, Size=7 },
           new Shirt {ShirtId=3, Brand = "W Brand", Color ="Purple", Gender="women", Price = 30, Size=7 },
           new Shirt {ShirtId=4, Brand = "W Brand", Color ="Black", Gender="men", Price = 30, Size=10 },
           new Shirt {ShirtId=5, Brand = "Y Brand", Color ="White", Gender="women", Price = 10, Size = 6 }
        };

        [HttpGet]
        public IActionResult GetShirts() {
            return Ok("Reading all the shirts");
        }
        //mapping from rount to input props
        //[HttpGet("{id}/{color}")]
        //the following is to use querystring to input color, also it can be input from Header
        [HttpGet("{id}")]       
        public ActionResult<Shirt> GetShirtById(int id, [FromQuery(Name = nameof(color))] string? color) {
            if (id <= 0)
                return BadRequest($"The input shirId {id} should be larger than 0.");

            var shirt = shirts.FirstOrDefault(s => s.ShirtId.Equals(id));
            if (shirt == null)
                return NotFound();

            return Ok(shirt);
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
