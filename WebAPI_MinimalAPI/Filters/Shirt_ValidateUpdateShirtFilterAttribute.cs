using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPI_MinimalAPI.Models;



namespace WebAPI_MinimalAPI.Filters
{
    public class Shirt_ValidateUpdateShirtFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var id = context.ActionArguments["id"] as int?;
            var shirt = context.ActionArguments["shirt"] as Shirt;

            if (id.HasValue && id != shirt.ShirtId) {
                context.ModelState.AddModelError("ShirtId", "ShirtId is not the same as id");
                var problemDetail = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                context.Result = new BadRequestObjectResult(problemDetail);
            }

        }
    }
}
