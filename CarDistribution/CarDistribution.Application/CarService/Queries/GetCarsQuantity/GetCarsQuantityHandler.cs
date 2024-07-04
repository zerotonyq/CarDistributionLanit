using CarDistribution.Application.CarService.Queries.GetCarsQuantity.Contracts;
using CarDistribution.Infrastructure.CarRepository;
using MediatR;

namespace CarDistribution.Application.CarService.Queries.GetCarsQuantity;

public class GetCarsQuantityHandler(CarRepository carRepository) : IRequestHandler<GetCarsQuantityQuery, GetCarsQuantityQueryResponse>
{
    public async Task<GetCarsQuantityQueryResponse> Handle(GetCarsQuantityQuery request, CancellationToken cancellationToken)
    {
        
        var responseInternal = await carRepository.GetCarsQuantity(cancellationToken);
        
        var response = new GetCarsQuantityQueryResponse()
        {
            CarDealerships = responseInternal.CarDealerships
        };

        return response;
    }
}