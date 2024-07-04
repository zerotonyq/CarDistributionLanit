using CarDistribution.Domain.Entities;
using Dapper;

namespace CarDistribution.Infrastructure.CarRepository.Query;

public class CarQuery
{
    public static CommandDefinition GetCarQuantity(Car car, CancellationToken cancellationToken)
    {
        const string sqlQuery = @"
        select car_dealership_id as ID, count(id) as Quantity from cars where 
                                       brand = @Brand and 
                                       color = @Color and
                                       car_dealership_id = @CarDealershipId 
                                   group by car_dealership_id   
        ";

        CommandDefinition command = new CommandDefinition(sqlQuery, new { car.Brand, car.Color, car.CarDealershipId },
            cancellationToken: cancellationToken);

        return command;
    }

    public static CommandDefinition GetCarQuantity(CancellationToken cancellationToken)
    {
        const string sqlQuery = @"
        select car_dealership_id as ID, count(id) as Quantity from cars 
                                   group by car_dealership_id
        ";

        CommandDefinition command = new CommandDefinition(sqlQuery,
            cancellationToken: cancellationToken);

        return command;
    }
}