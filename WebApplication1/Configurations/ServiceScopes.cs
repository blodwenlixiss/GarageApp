using WebApplication1.Interfaces;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Configurations;

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
/* 
builder.Services.AddScoped<IGarageRepository, GarageRepository>();
builder.Services.AddScoped<IGarageService, GarageService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>(); */