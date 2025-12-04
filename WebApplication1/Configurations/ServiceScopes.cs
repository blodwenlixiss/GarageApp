using Application.Services;
using Domain.IRepository;
using Infrastructure.Repositories;
using WebApplication1.Interfaces;
using WebApplication1.Services;

namespace WebApplication1;

public static class ServiceScopes
{
    public static IServiceCollection AddScopes(this IServiceCollection services)
    {
        services.AddScoped<IGarageRepository, GarageRepository>();
        services.AddScoped<IGarageService, GarageService>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<ICarService, CarService>();

        return services;
    }
}
