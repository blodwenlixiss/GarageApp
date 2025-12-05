using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Configurations;

public static class DbConfiguration 
{
    public static IServiceCollection AddDbConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


        return services;
    }
}