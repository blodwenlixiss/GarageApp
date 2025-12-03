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

    [HttpPost]
    public async Task<IActionResult> CreateCarAsync(CarDto car)
    {
        await _carService.CreateCarAsync(car);
        return Ok("Car is Added");
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

    [HttpDelete("{carId:guid}")]
    public async Task<IActionResult> DeleteCar(Guid carId)
    {
        await _carService.DeleteCar(carId);
        return Ok("Car is deleted Succesfully");
    }
}