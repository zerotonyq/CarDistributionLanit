using CarDistribution.Application.CarDealershipService.Queries.Contracts;
using CarDistribution.Infrastructure.CarDealershipRepository;
using MediatR;

namespace CarDistribution.Application.CarDealershipService.Queries;

public class GetCarDealershipsHandler(CarDealershipRepository carDealershipRepository) : IRequestHandler<GetCarDealershipQuery, GetCarDealershipQueryResponse>
{
    public async Task<GetCarDealershipQueryResponse> Handle(GetCarDealershipQuery request, CancellationToken cancellationToken)
    {
        var responseInternal = await carDealershipRepository.GetCarDealerships(cancellationToken);

        var response = new GetCarDealershipQueryResponse();
        
        response.CarDealerships = responseInternal.CarDealerships;

        return response;
    }
}