using WebApplication1.Models.Dtos;

namespace WebApplication1.Services;

public interface IGarageService
{
    Task CreateGarageAsync(GarageDto garageDto);
    Task<IEnumerable<GarageReadDto>> GetAllGaragesAsync();
    Task DeleteGarageAsync(Guid garageId);
    Task UpdateGarageCapacityAsync(Guid garageId, int capacity);
    Task<bool> AddCarToGarageAsync(Guid garageId, Guid carId);
    Task<GarageReadDto> GetCarsInGarageAsync(Guid garageId);
    Task<bool> RemoveCarFromGarageAsync(Guid garageId, Guid carId);
}