using CarDistribution.Domain.Entities;

namespace CarDistribution.Application.CarDealershipService.Queries.Contracts;

public class GetCarDealershipQueryResponse
{
    public List<CarDealership> CarDealerships = new();
}