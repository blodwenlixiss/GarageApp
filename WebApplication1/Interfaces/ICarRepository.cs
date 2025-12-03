using WebApplication1.Models.Dtos;
using WebApplication1.Models.Entities;

namespace WebApplication1.Interfaces;

public interface ICarRepository
{
     Task CreateCarAsync(Car car);
     Task<bool> DeleteCarAsync(Guid carId);
     Task<IEnumerable<Car>> GetAllCarsAsync();
     Task<Car?> GetCarByIdAsync(Guid carId);
}
