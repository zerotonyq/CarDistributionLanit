using CarDistribution.Domain.Entities;

namespace CarDistribution.Infrastructure.CarDealershipRepository.Contracts;

public class GetCarDealershipIdsResponseInternal
{
    public List<CarDealership> CarDealerships = new();
}