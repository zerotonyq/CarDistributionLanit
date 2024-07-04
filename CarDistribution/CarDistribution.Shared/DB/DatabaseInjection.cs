using CarDistribution.Common.DB.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarDistribution.Common.DB;

public static class DatabaseInjection
{
    public static IServiceCollection Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseConfiguration>(configuration.GetSection(nameof( DatabaseConfiguration )));
        services.AddSingleton<DbConnectionFactory>();
        return services;
    }
}