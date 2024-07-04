using CarDistribution.Application.CarDealershipService.Commands.Create.Contracts;
using CarDistribution.Application.Mappers;
using CarDistribution.Domain.Entities;
using CarDistribution.Infrastructure.CarDealershipRepository;
using MediatR;

namespace CarDistribution.Application.CarDealershipService.Commands.Create;

public class CreateCarDealershipHandler(CarDealershipRepository carDealershipRepository)
    : IRequestHandler<CreateCarDealershipCommand, CreateCarDealershipResponse>
{
    public async Task<CreateCarDealershipResponse> Handle(CreateCarDealershipCommand createCarDealershipCommand,
        CancellationToken cancellationToken)
    {
        CarDealership? carDealership =
            CarDealershipMapper.CreateCarDealershipCommandToCarDealership(createCarDealershipCommand);

        await carDealershipRepository.Add(carDealership, cancellationToken);

        return new CreateCarDealershipResponse();
    }
}