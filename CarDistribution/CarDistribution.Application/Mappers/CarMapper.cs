using CarDistribution.Application.CarService.Commands.Create.Contracts;
using CarDistribution.Application.CarService.Queries.GetCarsQuantity.Contracts;
using CarDistribution.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace CarDistribution.Application.Mappers;


[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
internal static partial class CarMapper
{
    public static partial CreateCarCommand CarToCarCommand(Car car);

    public static partial Car CreateCarCommandToCar(CreateCarCommand createCarCommand);

    public static partial Car GetCarsQuantityQueryToCar(GetCarsQuantityQueryById getCarsQuantityQuery);

    public static partial GetCarsQuantityQueryById CarToGetCarsQuantityQuery(Car car);
   
}