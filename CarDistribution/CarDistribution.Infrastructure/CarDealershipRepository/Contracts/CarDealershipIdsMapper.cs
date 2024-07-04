using Riok.Mapperly.Abstractions;

namespace CarDistribution.Infrastructure.CarDealershipRepository.Contracts;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
public partial class CarDealershipIdsMapper
{
    public static partial GetCarDealershipIdsResponseDb FromInternalToDb(
        GetCarDealershipIdsResponseInternal getCarDealershipIdsResponseInternal);

    public static partial GetCarDealershipIdsResponseInternal FromDbToInternal(
        GetCarDealershipIdsResponseDb getCarDealershipIdsResponseDb);
}