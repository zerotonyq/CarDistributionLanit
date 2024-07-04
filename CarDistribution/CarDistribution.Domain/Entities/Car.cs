using CarDistribution.Domain.Entities.Base;

namespace CarDistribution.Domain.Entities;

public sealed class Car : BaseEntity
{
    public string Brand { get; set; }
    public string Color { get; set; }
    
    public int CarDealershipId { get; set; }
}