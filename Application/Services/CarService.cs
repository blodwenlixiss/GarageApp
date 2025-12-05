using Application.Dtos;
using Domain.Entities;
using Domain.IRepository;
using WebApplication1.Exceptions;
using WebApplication1.Mapper.Car;
using WebApplication1.Mapper.Garage;
using WebApplication1.Services;

namespace Application.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository repo)
    {
        _carRepository = repo;
    }

    public async Task CreateCarAsync(CarDtoRequest carDtoRequest)
    {
        var car = new Car
        {
            Make = carDtoRequest.Make,
            Model = carDtoRequest.Model,
            Color = carDtoRequest.Color,
            Year = carDtoRequest.Year,
        };

        await _carRepository.CreateCarAsync(car);
    }

    public async Task<IEnumerable<GarageResponseDto>> GetGaragesWithCarIdAsync(Guid carId)
    {
        var car = await _carRepository.CheckCarByIdAsync(carId) is false
            ? throw new NotFoundException($"Car with Id {carId} not fount")
            : true;

        var garages = await _carRepository.GetGaragesWithCarIdAsync(carId) ??
                      throw new NotFoundException($"Garages where car Id is {carId} not found");

        var garageList = garages.ToGarageResponseDtos();

        return garageList;
    }

    public async Task<IEnumerable<CarResponseDto>> GetAllCars()
    {
        var allCars = await _carRepository.GetAllCarsAsync();
        var allCar = allCars.ToCarResponseDtos();

        return allCar;
    }

    public async Task<CarResponseDto> GetCarByIdAsync(Guid carId)
    {
        var car = await _carRepository.GetCarByIdAsync(carId) ??
                  throw new NotFoundException($"Car with Id -> {carId} is not found");

        var carResponseDto = car.ToCarResponseDto();

        return carResponseDto;
    }

    public async Task DeleteCarAsync(Guid carId)
    {
        var car = await _carRepository.GetCarByIdAsync(carId) ??
                  throw new NotFoundException("Car not found");

        await _carRepository.DeleteCarAsync(car);
    }
}