using System.Data;
using CarDistribution.Common.DB;
using CarDistribution.Domain.Entities;
using CarDistribution.Infrastructure.CarDealershipRepository.Command;
using CarDistribution.Infrastructure.CarDealershipRepository.Contracts;
using CarDistribution.Infrastructure.CarDealershipRepository.Query;
using Dapper;

namespace CarDistribution.Infrastructure.CarDealershipRepository;

public class CarDealershipRepository(DbConnectionFactory factory)
{
    private readonly IDbConnection _connection = factory.CreateConnection();

    public async Task Add(CarDealership carDealership, CancellationToken cancellationToken)
    {
        var query = CarDealershipCommand.Create(carDealership, cancellationToken);

        int rowsAffected = await _connection.ExecuteAsync(query);

        if (rowsAffected == 0)
            throw new Exception("CarDealership creation failed");
    }

    public async Task<GetCarDealershipIdsResponseInternal> GetCarDealerships(CancellationToken cancellationToken)
    {
        var query = CarDealershipQuery.CreateGet(cancellationToken);

        var resultFromDb = await _connection.QueryAsync<CarDealership>(query);
        
        if (resultFromDb == null) return null;

        var response = new GetCarDealershipIdsResponseInternal();
        
        foreach (var carDealership in resultFromDb)
        {
            response.CarDealerships.Add(carDealership);
        }

        return response;
    }
}