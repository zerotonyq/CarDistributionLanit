using MediatR;

namespace CarDistribution.Application.CarDealershipService.Commands.Create.Contracts;

public record CreateCarDealershipCommand(
    string Name,
    int CarMaxQuantity
) : IRequest<CreateCarDealershipResponse>
{
}