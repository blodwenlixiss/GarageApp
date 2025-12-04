using WebApplication1.Interfaces;
using WebApplication1.Mapper.Car;
using WebApplication1.Mapper.Garage;
using WebApplication1.Models.Dtos;
using WebApplication1.Models.Entities;

namespace WebApplication1.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository repo)
    {
        _carRepository = repo;
    }

    public async Task CreateCarAsync(CarDtoRequest carDtoRequest)
    {
        var newCar = new Car
        {
            Make = carDtoRequest.Make,
            Model = carDtoRequest.Model,
            Color = carDtoRequest.Color,
            Year = carDtoRequest.Year,
        };

        await _carRepository.CreateCarAsync(newCar);
    }

    public async Task<IEnumerable<GarageReadDtoResponse>> GetGaragesWithCarId(Guid carId)
    {
        var garages = await _carRepository.GetGaragesWithCarId(carId);
        var garageList = garages.ToGarageReadDto();
        return garageList;
    }

    public async Task<IEnumerable<CarDtoResponse>> GetAllCars()
    {
        var allCars = await _carRepository.GetAllCarsAsync();
        var allCar = allCars.ToCarReadDto();

        return allCar;
    }

    public async Task<CarDtoResponse>? GetCarById(Guid carId)
    {
        var carById = await _carRepository.GetCarByIdAsync(carId);
        if (carById == null)
        {
            throw new Exception("Car is not found");
        }

        var carSingle = carById.ToCarReadSoloDto();

        return carSingle;
    }

    public async Task<bool> DeleteCar(Guid carId)
    {
        var deletingCar = await _carRepository.DeleteCarAsync(carId);
        if (!deletingCar)
        {
            return false;
        }

        return true;
    }
}