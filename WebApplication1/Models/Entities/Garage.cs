namespace WebApplication1.Models.Entities;

public class Garage
{
    public Guid GarageId { get; set; } = Guid.NewGuid();
    public required string GarageName { get; set; }
    public int Capacity { get; set; }

    public ICollection<CarGarage> CarGarages { get; set; } = [];
}
