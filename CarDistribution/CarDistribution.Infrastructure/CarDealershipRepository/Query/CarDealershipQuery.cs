using CarDistribution.Domain.Entities;
using Dapper;

namespace CarDistribution.Infrastructure.CarDealershipRepository.Query;

public class CarDealershipQuery
{
    public static CommandDefinition CreateGet(CancellationToken cancellationToken)
    {
        const string sqlQuery = @"
        select id, car_max_quantity as CarMaxQuantity from car_dealerships limit 2
        ";

        CommandDefinition command = new CommandDefinition(sqlQuery,
            cancellationToken: cancellationToken);

        return command;
    }
}