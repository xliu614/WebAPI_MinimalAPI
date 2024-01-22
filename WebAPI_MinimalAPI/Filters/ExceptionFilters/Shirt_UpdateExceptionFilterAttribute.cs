using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPI_MinimalAPI.Models.Repositories;

namespace WebAPI_MinimalAPI.Filters.ExceptionFilters
{
    public class Shirt_UpdateExceptionFilterAttribute:ExceptionFilterAttribute
    {
        private readonly IShirtRepository _shirtRepository;

        public Shirt_UpdateExceptionFilterAttribute(IShirtRepository shirtRepository)
        {
            this._shirtRepository = shirtRepository;

        }

        public override void OnException(ExceptionContext context)
        {
            var strShirtId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strShirtId, out int shirtId)) 
            {
                if (!_shirtRepository.ShirtExists(shirtId))
                {
                    context.ModelState.AddModelError("Shirt", "The shirt has already been removed");
                    var problemDetail = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound,
                    };
                    context.Result = new NotFoundObjectResult(problemDetail);

                }
            }
        }
    }
}
