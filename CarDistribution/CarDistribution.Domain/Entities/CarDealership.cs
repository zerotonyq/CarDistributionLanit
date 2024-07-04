using CarDistribution.Domain.Entities.Base;

namespace CarDistribution.Domain.Entities;

public sealed class CarDealership : BaseEntity
{
    public string Name { get; set; }
    public int CarMaxQuantity { get; set; }
}