using Microsoft.EntityFrameworkCore;
using JxtauBlazor.Server.Helpers;
using JxtauBlazor.Server.Data;
using JxtauBlazor.Server.Interfaces;

namespace JxtauBlazor.Server.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<AppealContext>(options => {
                options.UseSqlServer(config.GetConnectionString("AppealConnection"));
            });
            // services.AddDbContext<PlanDataContext>(options => { options.UseSqlServer(config.GetConnectionString("PlanDataConnection")); });

            return services;
        }
    }
}