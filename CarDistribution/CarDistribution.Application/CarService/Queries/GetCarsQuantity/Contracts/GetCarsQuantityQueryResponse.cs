using CarDistribution.Domain.Entities.DTO;

namespace CarDistribution.Application.CarService.Queries.GetCarsQuantity.Contracts;

public class GetCarsQuantityQueryResponse
{
    public List<CarDealershipDto> CarDealerships = new();
}

