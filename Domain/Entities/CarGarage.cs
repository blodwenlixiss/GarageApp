using Domain.Entities;

namespace WebApplication1.Entities;

public class CarGarage
{
    public Guid CarId { get; set; }
    public Car Car { get; set; }

    public Guid GarageId { get; set; }
    public Garage Garage { get; set; }

    public int Quantity { get; set; }
}