﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPI_MinimalAPI.Models.Repositories;

namespace WebAPI_MinimalAPI.Filters.ActionFilters
{
    public class Shirt_ValidateShirtIdFilterAttribute : ActionFilterAttribute
    {
        private readonly IShirtRepository _shirtRepository;

        public Shirt_ValidateShirtIdFilterAttribute(IShirtRepository shirtRepository)
        {
            this._shirtRepository = shirtRepository;

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var shirtId = context.ActionArguments["id"] as int?;

            if (shirtId.HasValue)
            {
                if (shirtId.Value <= 0)
                {
                    context.ModelState.AddModelError("ShirtId", "ShirtId is invalid");
                    //If direct return context.ModelState in the Object Result, the displayed type can be different.
                    var problemDetail = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };
                    context.Result = new BadRequestObjectResult(problemDetail);
                }
                else
                {
                    var shirt = _shirtRepository.GetShirtByid(shirtId.Value);
                    if (shirt == null)
                    {
                        context.ModelState.AddModelError("ShirtId", "ShirtId does not exist");

                        var problemDetail = new ValidationProblemDetails(context.ModelState)
                        {
                            Status = StatusCodes.Status404NotFound,
                        };
                        context.Result = new NotFoundObjectResult(problemDetail);
                    }
                    else
                    {
                        context.HttpContext.Items["shirt"] = shirt;
                    }
                }                
            }

        }
    }
}
