using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ContextService
    {
        public static IServiceCollection AddContextService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>
            (x => x.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}