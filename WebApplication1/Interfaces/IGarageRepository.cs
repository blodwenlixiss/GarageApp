using WebApplication1.Models.Entities;

namespace WebApplication1.Interfaces;

public interface IGarageRepository
{
    Task CreateGarageAsync(Garage garage);
    Task<bool> DeleteGarageAsync(Guid garageId);
    Task<IEnumerable<Garage>> GetAllGaragesAsync();
    Task<bool> UpdateCapacityOfGarageAsync(Guid garageId, int newCapacity);
    Task<Garage?> GetGarageByIdAsync(Guid garageId);
    Task<bool> AddCarToGarageAsync(CarGarage carGarage);
    Task<bool> RemoveCarFromGarageAsync(Guid garageId, Guid carId);

}