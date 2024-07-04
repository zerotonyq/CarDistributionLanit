using CarDistribution.Application.CarDealershipService.Queries;
using CarDistribution.Application.CarDealershipService.Queries.Contracts;
using CarDistribution.Application.CarService.Commands.Create.Contracts;
using CarDistribution.Application.CarService.Queries;
using CarDistribution.Application.CarService.Queries.GetCarsQuantity;
using CarDistribution.Application.CarService.Queries.GetCarsQuantity.Contracts;
using CarDistribution.Application.Distribution;
using CarDistribution.Application.Mappers;
using CarDistribution.Domain.Entities;
using CarDistribution.Infrastructure.CarRepository;
using MediatR;

namespace CarDistribution.Application.CarService.Commands.Create;

public class CreateCarHandler(
    CarRepository carRepository,
    GetCarDealershipsHandler carDealershipsHandler,
    GetCarsQuantityByIdHandler getCarsQuantityByIdHandler,
    GetCarsQuantityHandler getCarsQuantityHandler) : IRequestHandler<CreateCarCommand, CreateCarResponse>
{
    public async Task<CreateCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        Car? car = CarMapper.CreateCarCommandToCar(request);

        var carDealershipsQueryResponse =
            await carDealershipsHandler.Handle(new GetCarDealershipQuery(), cancellationToken);

        var carsQuantityResponse = 
            await getCarsQuantityHandler.Handle(new GetCarsQuantityQuery(), cancellationToken);
        
        

        System.Collections.Generic.Dictionary<int, int> idsQuantities = new();

        foreach (var carDealership in carDealershipsQueryResponse.CarDealerships)
        {
            var responseQuantity =
                await getCarsQuantityByIdHandler.Handle(
                    new GetCarsQuantityQueryById(carDealership.Id, car.Brand, car.Color),
                    cancellationToken);
            idsQuantities.TryAdd(carDealership.Id, responseQuantity.Quantity);
        }

        var distributedId =
            DistributionHandler.GetIdByProbability(
                new KeyValuePair<int, int>(carDealershipsQueryResponse.CarDealerships[0].Id,
                    idsQuantities[carDealershipsQueryResponse.CarDealerships[0].Id]),
                new KeyValuePair<int, int>(carDealershipsQueryResponse.CarDealerships[1].Id,
                    idsQuantities[carDealershipsQueryResponse.CarDealerships[1].Id]));

        car.CarDealershipId = distributedId;

        Console.WriteLine(carsQuantityResponse.CarDealerships.Count);
        var dealership = carsQuantityResponse.CarDealerships.Find(cd => cd.id == car.CarDealershipId);
        
        if (dealership != null && dealership!.quantity >= carDealershipsQueryResponse.CarDealerships
                .Find(cd => cd.Id == car.CarDealershipId)!.CarMaxQuantity)
            return new CreateCarResponse(false);

        await carRepository.Add(car, cancellationToken);

        return new CreateCarResponse(true);
    }
}