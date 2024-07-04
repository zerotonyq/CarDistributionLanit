namespace CarDistribution.Domain.Entities.DTO;

public class CarDealershipDto
{
    public int id{ get; set; }
    public long quantity{ get; set; }


    public CarDealershipDto(int id, long quantity)
    {
        this.id = id;
        this.quantity = quantity;

    }
}