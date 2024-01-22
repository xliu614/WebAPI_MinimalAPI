using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPI_MinimalAPI.Models;
using WebAPI_MinimalAPI.Models.Repositories;

namespace WebAPI_MinimalAPI.Filters.ActionFilters
{
    public class Shirt_ValidateCreateShirtPropsFilterAttribute : ActionFilterAttribute
    {
        private readonly IShirtRepository _shirtRepository;
        public Shirt_ValidateCreateShirtPropsFilterAttribute(IShirtRepository shirtRepository)
        {
            this._shirtRepository = shirtRepository;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var shirt = context.ActionArguments["shirt"] as Shirt;
            if (shirt == null)
            {
                // Perform your custom filtering/validation logic here
                context.ModelState.AddModelError("Shirt", "Shirt object is null");
                var problemDetail = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                context.Result = new BadRequestObjectResult(problemDetail);
            }
            else
            {
                var existingShirt = _shirtRepository.GetShirtByProps(shirt.Brand, shirt.Gender, shirt.Color, shirt.Size);
                if (existingShirt != null)
                {
                    context.ModelState.AddModelError("ShirtProps", "Shirt already exists");
                    var problemDetail = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };
                    context.Result = new BadRequestObjectResult(problemDetail);
                }
            }
        }
    }
}
