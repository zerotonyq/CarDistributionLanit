using System.Data;
using CarDistribution.Common.DB.Config;
using Microsoft.Extensions.Options;
using Npgsql;

namespace CarDistribution.Common.DB;

public class DbConnectionFactory(IOptionsMonitor<DatabaseConfiguration> dbSettings)
{
    private static NpgsqlConnection? _existingConnection;

    public IDbConnection CreateConnection()
    {
        if (_existingConnection != null) { return _existingConnection; }
        
        string connectionString = CreateConnectionString(dbSettings.CurrentValue);

        var connection = new NpgsqlConnection(connectionString);
        
        _existingConnection = connection;

        return connection;
    }

    private static string CreateConnectionString(DatabaseConfiguration databaseConfiguration)
    {
        return $"Host={databaseConfiguration.Server}; " +
               $"Database={databaseConfiguration.Database}; " +
               $"Username={databaseConfiguration.Username}; " +
               $"Password={databaseConfiguration.Password};";
    }
}