using WebApplication1.Models.Dtos;

namespace WebApplication1.Services;

public interface ICarService
{
    Task CreateCarAsync(CarDto carDto);
    Task<IEnumerable<CarDtoRead>> GetAllCars();
    Task<CarDtoRead>? GetCarById(Guid carId);
    Task<bool> DeleteCar(Guid carId);
}