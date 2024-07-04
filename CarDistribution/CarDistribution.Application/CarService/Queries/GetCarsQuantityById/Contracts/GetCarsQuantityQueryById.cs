using MediatR;

namespace CarDistribution.Application.CarService.Queries.GetCarsQuantity.Contracts;

public record GetCarsQuantityQueryById(int? CarDealershipId = null, string? Brand = null, string? Color =null) : IRequest<GetCarsQuantityQueryByIdResponse>
{
    
}