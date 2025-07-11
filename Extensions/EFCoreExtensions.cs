using Microsoft.EntityFrameworkCore;
using WebApplication7.Data;

namespace WebApplication7.Extensions
{
    public static class EFCoreExtensions
    {
        public static IServiceCollection DBContextInjection(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(
                config.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(config.GetConnectionString("DefaultConnection"))
            )
        );

        return services;
        }
    }
}
