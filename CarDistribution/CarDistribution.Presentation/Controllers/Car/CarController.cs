using System.Net;
using CarDistribution.Application.CarService.Commands.Create.Contracts;
using CarDistribution.Application.CarService.Queries.GetCarsQuantity.Contracts;
using CarDistribution.Domain.Entities.DTO;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarDistribution.Controllers.Car;

[ApiController]
[Route("[controller]")]
public class CarController(IMediator mediator)
{
    [HttpPost(nameof(Create))]
    public async Task<IActionResult> Create(CreateCarCommand createCarCommand, CancellationToken cancellationToken)
    {
            var resp = await mediator.Send(createCarCommand, cancellationToken);
        
            if (resp.succeeded)
            {
                return new AcceptedResult();
            }
            else
            {
                return new ConflictResult();
            }
    }

    [HttpGet($"/{nameof(GetCarsQuantityInCarDealership)}/")]
    public async Task<List<CarDealershipDto>> GetCarsQuantityInCarDealership()
    {
        var getCarsQuantityQuery = new GetCarsQuantityQuery();
        var resp =  await mediator.Send(getCarsQuantityQuery);

       
        return resp.CarDealerships;
    }
}