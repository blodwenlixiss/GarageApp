using Domain.Entities;
using WebApplication1.Entities;

namespace Domain.IRepository;

public interface ICarRepository
{
    Task CreateCarAsync(Car car);
    Task DeleteCarAsync(Car car);
    Task<IEnumerable<Car>> GetAllCarsAsync();
    Task<Car?> GetCarByIdAsync(Guid carId);
    Task<bool> CheckCarByIdAsync(Guid carId);
    Task<IEnumerable<Garage>> GetGaragesWithCarIdAsync(Guid carId);
}