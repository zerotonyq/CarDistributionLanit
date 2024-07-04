using CarDistribution.Domain.Entities;
using Dapper;

namespace CarDistribution.Infrastructure.CarDealershipRepository.Command;

public class CarDealershipCommand
{
    public static CommandDefinition Create(CarDealership carDealership, CancellationToken cancellationToken)
    {
        const string sqlQuery = @"
        insert into car_dealerships (
                         Name,
                         car_max_quantity
        ) values (
                  @Name,
                  @carMaxQuantity
        ) 
        ";

        CommandDefinition command = new CommandDefinition(sqlQuery,
            new { carDealership.Name, carDealership.CarMaxQuantity },
            cancellationToken: cancellationToken);

        return command;
    }
}