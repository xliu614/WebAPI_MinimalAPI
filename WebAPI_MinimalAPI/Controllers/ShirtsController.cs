using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_MinimalAPI.Models;

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
        //the following is to use querystring to input color, also it can be input from Header
        [HttpGet("{id}")]       
        public string GetShirtById(int id, [FromQuery(Name = nameof(color))] string color) {
            return $"Read the shirt with ID: {id} and color: {color}";
        }
        /// <summary>
        /// FromBody raw/FromForm with key value pair, here Shirt is used as model binding
        /// </summary>
        /// <param name="shirt"></param>
        /// <returns></returns>
        [HttpPost]       
        public string CreateShirt([FromForm] Shirt shirt) {
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
