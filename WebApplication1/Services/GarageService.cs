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

    public async Task CreateGarageAsync(GarageDtoRequest garageDtoRequest)
    {
        var newGarage = new Garage
        {
            GarageName = garageDtoRequest.GarageName,
            Capacity = garageDtoRequest.Capacity,
        };

        await _garageRepository.CreateGarageAsync(newGarage);
    }

    public async Task<GarageReadDtoResponse> GetCarsInGarageAsync(Guid garageId)
    {
        var cars = await _garageRepository.GetGarageByIdAsync(garageId);
        if (cars is null) throw new NotFoundException($"Garage is not found! with Id:{garageId}");
        var cars1 = cars.ToGarageDto();

        return cars1;
    }

    public async Task<IEnumerable<GarageReadDtoResponse>> GetAllGaragesAsync()
    {
        var allGarages = await _garageRepository.GetAllGaragesAsync();
        var allGaragesDto = allGarages.ToGarageReadDto();
        return allGaragesDto;
    }

    public async Task DeleteGarageAsync(Guid garageId)
    {
        var garage = await _garageRepository.DeleteGarageAsync(garageId);
        if (!garage)
        {
            throw new Exception("There is no such garage");
        }
    }

    public async Task UpdateGarageCapacityAsync(Guid garageId, int capacity)
    {
        await _garageRepository.UpdateCapacityOfGarageAsync(garageId, capacity);
    }

    public async Task<bool> AddCarToGarageAsync(Guid garageId, Guid carId)
    {
        var carExists = await _carRepository.CheckCarByIdAsync(carId);
        if (!carExists)
            throw new NotFoundException("Car is not found");

        var garageExists = await _garageRepository.CheckGarageById(garageId);
        if (!garageExists)
            throw new NotFoundException("Garage is not found");

        var carGarage = await _garageRepository.CarGarageByIdAsync(garageId, carId);
        if (carGarage != null)
        {
            if (carGarage.Garage.Capacity <= carGarage.Quantity)
                throw new BadRequestException("There is no more space in the garage");

            carGarage.Quantity++;
            await _garageRepository.UpdateCarGarageAsync(carGarage);
        }
        else
        {
            var newCarGarage = new CarGarage
            {
                CarId = carId,
                GarageId = garageId,
                Quantity = 1
            };

            await _garageRepository.AddCarToGarageAsync(newCarGarage);
        }

        if (carGarage.Garage.Capacity <= carGarage.Quantity)
            throw new BadRequestException("There is no more space in the garage");
        return true;
    }

    public async Task<bool> RemoveCarFromGarageAsync(Guid garageId, Guid carId)
    {
        var garage = await _garageRepository.CheckGarageById(garageId);
        if (!garage)
            throw new NotFoundException($"The Garage with Id: {garageId} is not found");

        var car = await _carRepository.CheckCarByIdAsync(carId);
        if (!car)
            throw new NotFoundException($"The Car with id: {carId} is not found");

        var cg = await _garageRepository.CarGarageByIdAsync(garageId, carId);
        if (cg.Quantity > 1)
        {
            cg.Quantity--;
          await _garageRepository.UpdateCarGarageAsync(cg);
        }
        else
        {
            await _garageRepository.RemoveCarFromGarageAsync(cg);
        }

        return true;
    }
}