using Application.Dtos;
using Domain.Exceptions;
using Domain.IRepository;
using WebApplication1.Entities;
using WebApplication1.Exceptions;
using WebApplication1.Interfaces;
using WebApplication1.Mapper.Car;
using WebApplication1.Mapper.Garage;

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

    public async Task CreateGarageAsync(GarageRequestDto garageRequestDto)
    {
        var garage = new Garage
        {
            GarageName = garageRequestDto.GarageName,
            Capacity = garageRequestDto.Capacity,
        };

        await _garageRepository.CreateGarageAsync(garage);
    }

    public async Task<GarageResponseDto> GetGarageByIdAsync(Guid garageId)
    {
        var cars = await _garageRepository.GetGarageByIdAsync(garageId) ??
                   throw new NotFoundException($"Garage is not found! with Id:{garageId}");

        var garageDto = cars.ToGarageDto();

        return garageDto;
    }

    public async Task<IEnumerable<GarageResponseDto>> GetAllGaragesAsync()
    {
        var allGarages = await _garageRepository.GetAllGaragesAsync();
        var allGaragesDto = allGarages.ToGarageResponseDtos();
        return allGaragesDto;
    }

    public async Task DeleteGarageByIdAsync(Guid garageId)
    {
        var garage = await _garageRepository.GetGarageByIdAsync(garageId) ??
                     throw new NotFoundException("There is no such garage");

        await _garageRepository.DeleteGarageAsync(garage);
    }

    public async Task UpdateGarageCapacityAsync(Guid garageId, int capacity)
    {
        var garage = await _garageRepository.GetGarageByIdAsync(garageId) ??
                     throw new NotFoundException("There is no such garage");

        var cars = garage.CarGarages.Select(x => x.Car);

        var carQuantity = cars.Count();

        if (capacity < carQuantity)
            throw new BadRequestException("You cant Change Quantity");

        garage.Capacity = capacity;

        await _garageRepository.UpdateGarageAsync(garage);
    }

    public async Task<bool> AddCarToGarageAsync(CarRequestDto carRequestDto)
    {
        var carExists = await _carRepository.CheckCarByIdAsync(carRequestDto.CarId) is false ?
                        throw new NotFoundException("Car is not found") : true;

        var garageExists = await _garageRepository.CheckGarageById(carRequestDto.GarageId) is false ?
            throw new NotFoundException("Garage is not found") : true;

        var carGarageById = await _garageRepository.GetCarGarageByIdAsync(carRequestDto.GarageId,carRequestDto.CarId);

        if (carGarageById != null)
        {
            if (carGarageById.Garage.Capacity <= carGarageById.Quantity)
                throw new BadRequestException("There is no more space in the garage");

            carGarageById.Quantity++;
            await _garageRepository.UpdateCarGarageAsync(carGarageById);
        }
        else
        {
            var carGarage = new CarGarage
            {
                CarId = carRequestDto.CarId,
                GarageId = carRequestDto.GarageId,
                Quantity = 1
            };

            await _garageRepository.AddCarToGarageAsync(carGarage);
        }

        if (carGarageById?.Garage.Capacity <= carGarageById?.Quantity)
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

        var carGarage = await _garageRepository.GetCarGarageByIdAsync(garageId, carId)??
                        throw new NotFoundException("Car not found");

        if (carGarage.Quantity > 1)
        {
            carGarage.Quantity--;
            await _garageRepository.UpdateCarGarageAsync(carGarage);
        }
        else
        {
            await _garageRepository.RemoveCarFromGarageAsync(carGarage);
        }

        return true;
    }
}