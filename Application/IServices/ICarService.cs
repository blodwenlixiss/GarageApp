using Application.Dtos;

namespace WebApplication1.Services;

public interface ICarService
{
    Task CreateCarAsync(CarDtoRequest carDtoRequest);
    Task<IEnumerable<CarResponseDto>> GetAllCars();
    Task<CarResponseDto>? GetCarByIdAsync(Guid carId);
    Task DeleteCarAsync(Guid carId);
    Task<IEnumerable<GarageResponseDto>> GetGaragesWithCarIdAsync(Guid carId);
}