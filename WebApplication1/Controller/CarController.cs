using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Dtos;
using WebApplication1.Services;

namespace WebApplication1.Controller;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService service)
    {
        _carService = service;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllCars()
    {
        var allCars = await _carService.GetAllCars();
        return Ok(allCars);
    }

    [HttpGet("{carId:guid}")]
    public async Task<IActionResult> GetCarByIdAsync(Guid carId)
    {
        var singleCar = await _carService.GetCarById(carId)!;
        if (singleCar == null) throw new Exception("Car is not exist");

        return Ok(singleCar);
    }

    [HttpGet("Garages/{carId:guid}")]
    public async Task<IActionResult> GetGaragesWithCarId(Guid carId)
    {
        var garages = await _carService.GetGaragesWithCarId(carId);
        return Ok(garages);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCarAsync(CarDtoRequest car)
    {
        await _carService.CreateCarAsync(car);
        return Ok("Car is Added");
    }

    [HttpDelete("{carId:guid}")]
    public async Task<IActionResult> DeleteCar(Guid carId)
    {
        await _carService.DeleteCar(carId);
        return Ok("Car is deleted Succesfully");
    }
}