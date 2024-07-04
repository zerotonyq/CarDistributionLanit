using CarDistribution.Domain.Entities;
using Dapper;

namespace CarDistribution.Infrastructure.CarRepository.Command;

public class CarCommand
{
    public static CommandDefinition Create(Car car, CancellationToken cancellationToken)
    {
        const string sqlQuery = @"
        insert into Cars (
                         brand,
                         color,
                         car_dealership_id
        ) values (
                  @Brand,
                  @Color,
                  (select id from car_dealerships where id = @CarDealershipId)
        ) 
        ";

        CommandDefinition command = new CommandDefinition(sqlQuery, new { car.Brand, car.Color, car.CarDealershipId },
            cancellationToken: cancellationToken);

        return command;
    }
}