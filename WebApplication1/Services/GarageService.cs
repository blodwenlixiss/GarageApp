using WebApplication1.Exceptions;
using WebApplication1.Interfaces;
using WebApplication1.Mapper.Car;
using WebApplication1.Mapper.Garage;
using WebApplication1.Models.Dtos;
using WebApplication1.Models.Entities;

namespace WebApplication1.Services;

public class GarageService : IGarageService
{
    private readonly IGarageRepository _garageRepository;
    private readonly ICarRepository _carRepository;

    public GarageService(IGarageRepository garageRepo, ICarRepository carRepository)
    {
        _garageRepository = garageRepo;
        _carRepository = carRepository;
    }

    public async Task CreateGarageAsync(GarageDto garageDto)
    {
        var newGarage = new Garage
        {
            GarageName = garageDto.GarageName,
            Capacity = garageDto.Capacity,
        };

        await _garageRepository.CreateGarageAsync(newGarage);
    }

    public async Task<GarageReadDto> GetCarsInGarageAsync(Guid garageId)
    {
        var cars = await _garageRepository.GetGarageByIdAsync(garageId);
        if (cars is null) throw new NotFoundException($"Garage is not found! with Id:{garageId}");
        var cars1 = cars.ToGarageDto();
        
        return cars1; // using your existing mapper
    }

    public async Task<IEnumerable<GarageReadDto>> GetAllGaragesAsync()
    {
        var allGarages = await _garageRepository.GetAllGaragesAsync();
        var allGaragesDto = allGarages.ToGarageReadDto();
        return allGaragesDto;
    }

    public async Task DeleteGarageAsync(Guid garageId)
    {
       var garage =  await _garageRepository.DeleteGarageAsync(garageId);
       if (!garage)
       {
           throw new Exception("There is no such garage");
       }
    }

    public async Task UpdateGarageCapacityAsync(Guid garageId, int capacity)
    {
        await _garageRepository.UpdateCapacityOfGarageAsync(garageId, capacity);
    }
    public Task<bool> AddCarToGarageAsync(Guid garageId, Guid carId)
    {
        
        return _garageRepository.AddCarToGarageAsync(garageId, carId);
    }

    public async Task<bool> RemoveCarFromGarageAsync(Guid garageId, Guid carId)
    {
        await _garageRepository.RemoveCarFromGarageAsync(garageId, carId);

        return true;
    }
    
}