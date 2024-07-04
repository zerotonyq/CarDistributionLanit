using CarDistribution.Application.CarDealershipService.Queries;
using CarDistribution.Application.CarDealershipService.Queries.Contracts;
using CarDistribution.Application.CarService.Commands.Create.Contracts;
using CarDistribution.Application.CarService.Queries.GetCarsQuantity.Contracts;
using CarDistribution.Application.Mappers;
using CarDistribution.Domain.Entities;
using CarDistribution.Infrastructure.CarRepository;
using MediatR;

namespace CarDistribution.Application.CarService.Queries;

public class GetCarsQuantityByIdHandler(CarRepository carRepository, GetCarDealershipsHandler handler) : IRequestHandler<GetCarsQuantityQueryById, GetCarsQuantityQueryByIdResponse>
{
    public async Task<GetCarsQuantityQueryByIdResponse> Handle(GetCarsQuantityQueryById request, CancellationToken cancellationToken)
    {
        Car? car = CarMapper.GetCarsQuantityQueryToCar(request);
        
        var responseInternal = await carRepository.GetCarsQuantity(car, cancellationToken);
        
        var response = new GetCarsQuantityQueryByIdResponse
        {
            Quantity = responseInternal.Quantity
        };

        return response;
    }
}