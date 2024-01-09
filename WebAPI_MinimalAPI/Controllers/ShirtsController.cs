using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_MinimalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        [HttpGet]
        public string GetShirts() {
            return "Reading all the shirts";
        }
        //mapping from rount to input props
        //[HttpGet("{id}/{color}")]
        //the following is to use querystring to input color
        [HttpGet("{id}")]       
        public string GetShirtById(int id, [FromQuery(Name = nameof(color))] string color) {
            return $"Read the shirt with ID: {id} and color: {color}";
        }

        [HttpPost]       
        public string CreateShirt() {
            return $"Created a shirt";
        }

        [HttpPut("{id}")]
        public string UpdateShirt(int id) {
            return $"Updated the shirt with ID: {id}";
        }
        [HttpDelete("{id}")]
        public string DeleteShirt(int id) {
            return $"Deleted the shirt with ID: {id}";
        }
    }
}
