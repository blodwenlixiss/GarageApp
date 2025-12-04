namespace WebApplication1.Models.Dtos;

public class GarageReadDtoResponse
{
    public Guid GarageId { get; set; } = Guid.NewGuid();
    public required string GarageName { get; set; }
    public int Capacity { get; set; }
    
    public List<CarGarageDto> Cars { get; set; } = [];
    
}