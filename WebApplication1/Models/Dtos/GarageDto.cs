using WebApplication1.Models.Entities;
namespace WebApplication1.Models.Dtos;

public class GarageDto
{    
    public required string GarageName { get; set; }
    public int Capacity { get; set; }

}
