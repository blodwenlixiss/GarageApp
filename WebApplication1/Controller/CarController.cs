using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
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
        var singleCar = await _carService.GetCarByIdAsync(carId)!;

        return Ok(singleCar);
    }

    [HttpGet("Garages/{carId:guid}")]
    public async Task<IActionResult> GetGaragesWithCarId(Guid carId)
    {
        var garages = await _carService.GetGaragesWithCarIdAsync(carId);

        return Ok(garages);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCarAsync(CarDtoRequest carDto)
    {
        await _carService.CreateCarAsync(carDto);

        return Ok("Car is Added");
    }

    [HttpDelete("{carId:guid}")]
    public async Task<IActionResult> DeleteCar(Guid carId)
    {
        await _carService.DeleteCarAsync(carId);

        return Ok("Car is deleted Successfully");
    }
}