using System.Data;
using CarDistribution.Common.DB;
using CarDistribution.Domain.Entities;
using CarDistribution.Domain.Entities.DTO;
using CarDistribution.Infrastructure.CarRepository.Command;
using CarDistribution.Infrastructure.CarRepository.Contracts;
using CarDistribution.Infrastructure.CarRepository.Query;
using Dapper;

namespace CarDistribution.Infrastructure.CarRepository;

public class CarRepository(DbConnectionFactory factory)
{
    private readonly IDbConnection _connection = factory.CreateConnection();

    public async Task Add(Car car, CancellationToken cancellationToken)
    {
        var query = CarCommand.Create(car, cancellationToken);

        int rowsAffected = await _connection.ExecuteAsync(query);

        if (rowsAffected == 0)
            throw new Exception("Car creation failed");
    }

    public async Task<GetCarsQuantityByIdResponseInternal> GetCarsQuantity(Car car, CancellationToken cancellationToken)
    {
        var query = CarQuery.GetCarQuantity(car, cancellationToken);

        var resultFromDb = await _connection.QuerySingleOrDefaultAsync<GetCarsQuantityByIdResponseDb>(query) ??
                           new GetCarsQuantityByIdResponseDb
                           {
                               Quantity = 0
                           };

        return CarsQuantityByIdMapper.ToInternal(resultFromDb);
    }
    
    public async Task<GetCarsQuantityResponseInternal> GetCarsQuantity(CancellationToken cancellationToken)
    {
        var query = CarQuery.GetCarQuantity(cancellationToken);

        var resultFromDb = await _connection.QueryAsync<CarDealershipDto>(query);

        var response = new GetCarsQuantityResponseDb();
        foreach (var dto in resultFromDb)
        {
            response.CarDealerships.Add(dto);
        }

        return CarsQuantityMapper.ToInternal(response);
    }
}