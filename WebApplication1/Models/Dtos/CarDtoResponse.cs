namespace WebApplication1.Models.Dtos;

public class CarDtoResponse
{
    public Guid CarId { get; set; }
    public required string Make { get; set; }
    public required string Model { get; set; }
    public int Year { get; set; }
    public required string Color { get; set; }

}