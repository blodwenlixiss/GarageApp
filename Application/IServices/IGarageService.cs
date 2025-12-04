using Application.Dtos;

namespace WebApplication1.Services;

public interface IGarageService
{
    Task CreateGarageAsync(GarageRequestDto garageRequestDto);
    Task<IEnumerable<GarageResponseDto>> GetAllGaragesAsync();
    Task DeleteGarageByIdAsync(Guid garageId);
    Task UpdateGarageCapacityAsync(Guid garageId, int capacity);
    Task<bool> AddCarToGarageAsync(CarRequestDto carRequestDto);
    Task<GarageResponseDto> GetGarageByIdAsync(Guid garageId);
    Task<bool> RemoveCarFromGarageAsync(Guid garageId, Guid carId);
}