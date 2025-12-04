using WebApplication1.Models.Dtos;

namespace WebApplication1.Services;

public interface ICarService
{
    Task CreateCarAsync(CarDtoRequest carDtoRequest);
    Task<IEnumerable<CarDtoResponse>> GetAllCars();
    Task<CarDtoResponse>? GetCarById(Guid carId);
    Task<bool> DeleteCar(Guid carId);
    Task<IEnumerable<GarageReadDtoResponse>> GetGaragesWithCarId(Guid carId);
}