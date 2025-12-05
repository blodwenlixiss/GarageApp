namespace Application.Dtos;

public class GarageResponseDto
{
    public Guid GarageId { get; set; } = Guid.NewGuid();
    public required string GarageName { get; set; }
    public int Capacity { get; set; }
    
    public List<CarGarageDto> Cars { get; set; } = [];
    
}