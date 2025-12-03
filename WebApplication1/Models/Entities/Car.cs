namespace WebApplication1.Models.Entities;

public class Car
{
    public Guid CarId { get; set; }
    public required string Make{ get; set; }
    public required string Model { get; set; }
    public required string Color { get; set; }
    public int Year { get; set; }


    public ICollection<CarGarage> CarGarages { get; set; } = [];
    
}
