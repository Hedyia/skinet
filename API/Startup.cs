using API.Extensions;
using API.Middlewares;
using API.Profiles;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddUnitOfWorkService();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddSignalR();
            services.AddContextService(_configuration);
            services.AddCors(options =>
           {
               options.AddPolicy("mypolicy", builder => builder
                .WithOrigins("https://localhost:4200")
                .SetIsOriginAllowed((host) => true)
                .AllowAnyMethod()
                .AllowAnyHeader());
           });
            services.AddControllers();
            services.AddHandleBadRequestService();
            services.AddOpenDocumentationService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();
            app.UseCors("mypolicy");

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseDocumentationService();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
