using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarDistribution.Infrastructure;

public static class InfrastructureInjection
{
    public static IServiceCollection Configure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<CarRepository.CarRepository>();
        services.AddSingleton<CarDealershipRepository.CarDealershipRepository>();
        return services;
    }
}