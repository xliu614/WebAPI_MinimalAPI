using Microsoft.AspNetCore.Http;
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
        private readonly IShirtRepository _shirtRepository;

        public ShirtsController(IShirtRepository shirtRepository)
        {
            this._shirtRepository = shirtRepository;

        }

        [HttpGet]
        public IActionResult GetShirts() {
            return Ok(_shirtRepository.GetShirts());
        }
        //mapping from rount to input props
        //[HttpGet("{id}/{color}")]
        //the following is to use querystring to input color, also it can be input from Header
        [HttpGet("{id}")]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        public ActionResult<Shirt> GetShirtById(int id, [FromQuery(Name = nameof(color))] string? color) {            
            return Ok(HttpContext.Items["shirt"]);
        }
        /// <summary>
        /// FromBody raw/FromForm with key value pair, here Shirt is used as model binding
        /// </summary>
        /// <param name="shirt"></param>
        /// <returns></returns>
        [HttpPost]
        [TypeFilter(typeof(Shirt_ValidateCreateShirtPropsFilterAttribute))]
        public IActionResult CreateShirt([FromBody] Shirt shirt) {
            
            _shirtRepository.AddShirt(shirt);
            return CreatedAtAction(nameof(GetShirtById),new { id = shirt.ShirtId }, shirt);
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        [Shirt_ValidateUpdateShirtFilter]
        [TypeFilter(typeof(Shirt_UpdateExceptionFilterAttribute))]
        public IActionResult UpdateShirt(int id, [FromBody] Shirt shirt) {
            //using try catch block here, because there's possibility that when shirt's updated, it's already been removed
            ShirtRepository.UpdateShirt(shirt);            

            return NoContent();
        }
        [HttpDelete("{id}")]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        public IActionResult DeleteShirt(int id) {

            var shirt = _shirtRepository.GetShirtByid(id);
            //ShirtRepository.RemoveShirt(id);
            return Ok(shirt);
        }
    }
}
