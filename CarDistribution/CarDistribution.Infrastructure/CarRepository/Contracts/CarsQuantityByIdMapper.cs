using Riok.Mapperly.Abstractions;

namespace CarDistribution.Infrastructure.CarRepository.Contracts;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
public partial class CarsQuantityByIdMapper
{
    public static partial GetCarsQuantityByIdResponseDb ToDb(
        GetCarsQuantityByIdResponseInternal getCarsQuantityByIdResponseInternal);

    public static partial GetCarsQuantityByIdResponseInternal ToInternal(
        GetCarsQuantityByIdResponseDb getCarsQuantityByIdResponseDb);
}