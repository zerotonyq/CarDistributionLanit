using MediatR;

namespace CarDistribution.Application.CarService.Commands.Create.Contracts;

public record CreateCarCommand
(
    string Brand,
    string Color
) : IRequest<CreateCarResponse>;