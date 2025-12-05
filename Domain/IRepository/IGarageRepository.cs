using WebApplication1.Entities;

namespace WebApplication1.Interfaces;

public interface IGarageRepository
{
    Task CreateGarageAsync(Garage garage);
    Task DeleteGarageAsync(Garage garage);
    Task<IEnumerable<Garage>> GetAllGaragesAsync();
    Task UpdateGarageAsync(Garage garage);
    Task<Garage?> GetGarageByIdAsync(Guid garageId);
    Task<bool> AddCarToGarageAsync(CarGarage carGarage);
    Task RemoveCarFromGarageAsync(CarGarage cg);
    Task<bool> CheckGarageById(Guid garageId);
    Task<CarGarage?> GetCarGarageByIdAsync(Guid garageId, Guid carId);
    Task UpdateCarGarageAsync(CarGarage entity);
}