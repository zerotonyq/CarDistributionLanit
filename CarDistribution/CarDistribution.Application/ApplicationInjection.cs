using System.Reflection;
using CarDistribution.Application.CarDealershipService.Commands.Create;
using CarDistribution.Application.CarDealershipService.Queries;
using CarDistribution.Application.CarService.Commands.Create;
using CarDistribution.Application.CarService.Queries;
using CarDistribution.Application.CarService.Queries.GetCarsQuantity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarDistribution.Application;

public static class ApplicationInjection
{
    public static IServiceCollection Configure(
        this IServiceCollection services, IConfiguration configuration)
    {

        services.AddSingleton<CreateCarHandler>();
        services.AddSingleton<CreateCarDealershipHandler>();
        services.AddSingleton<GetCarsQuantityByIdHandler>();
        services.AddSingleton<GetCarDealershipsHandler>();
        services.AddSingleton<GetCarsQuantityHandler>();
        return services;
    }
}