using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class OpenDocumentationService
    {
        public static IServiceCollection AddOpenDocumentationService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "Skinet Backend V1" });
            });
            return services;
        }

        public static IApplicationBuilder UseDocumentationService(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI
            (
                c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Skinet Backend V1");
                });
            return app;
        }
    }
}