using System.Linq;
using API.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class HandleBadRequestService
    {
        public static IServiceCollection AddHandleBadRequestService(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState.Where(err => err.Value.Errors.Count > 0)
                                              .SelectMany(x => x.Value.Errors)
                                              .Select(x => x.ErrorMessage);
                    var errorResponse = new ApiValidationErrorResponse { Errors = errors };
                    return new BadRequestObjectResult(errorResponse);
                };
            });
            return services;
        }
    }
}