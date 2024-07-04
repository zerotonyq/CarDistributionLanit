using CarDistribution.Domain.Entities.DTO;

namespace CarDistribution.Infrastructure.CarRepository.Contracts;

public class GetCarsQuantityResponseDb
{
    public List<CarDealershipDto> CarDealerships = new();
}