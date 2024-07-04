using Riok.Mapperly.Abstractions;

namespace CarDistribution.Infrastructure.CarRepository.Contracts;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
public partial class CarsQuantityMapper
{
    public static partial GetCarsQuantityResponseDb ToDb(
        GetCarsQuantityResponseInternal getCarsQuantityByIdResponseInternal);

    public static partial GetCarsQuantityResponseInternal ToInternal(
        GetCarsQuantityResponseDb getCarsQuantityByIdResponseDb);
}