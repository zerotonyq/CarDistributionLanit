using CarDistribution.Application.CarDealershipService.Commands.Create.Contracts;
using CarDistribution.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace CarDistribution.Application.Mappers;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
internal static partial class CarDealershipMapper
{ 
    public static partial CarDealership CreateCarDealershipCommandToCarDealership(CreateCarDealershipCommand createCarDealershipCommand);

    public static partial CreateCarDealershipCommand CarDealershipToCreateCarDealershipCommand(
        CarDealership carDealership);
}