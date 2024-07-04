using CarDistribution.Application.CarDealershipService.Commands.Create.Contracts;
using CarDistribution.Application.CarService.Commands.Create.Contracts;
using CarDistribution.Application.CarService.Queries.GetCarsQuantity.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarDistribution.Controllers.CarDealership;

[ApiController]
[Route("[controller]")]
public class CarDealershipController(IMediator mediator)
{
    [HttpPost(nameof(Create))]
    public async Task<CreateCarDealershipResponse> Create(CreateCarDealershipCommand createCarDealershipCommand, CancellationToken cancellationToken) =>
        await mediator.Send(createCarDealershipCommand, cancellationToken);

    
}