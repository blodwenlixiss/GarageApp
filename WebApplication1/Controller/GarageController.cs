using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controller;

[ApiController]
[Route("[controller]")]
public class GarageController : ControllerBase
{

    private readonly IGarageService _garageService;

    public GarageController(IGarageService service)
    {
        _garageService = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGarages()
    {
        var allGarages = await _garageService.GetAllGaragesAsync();

        return Ok(allGarages);
    }

    [HttpGet("{garageId:guid}")]
    public async Task<IActionResult> GetGarageByIdAsync(Guid garageId)
    {
        var garage = await _garageService.GetGarageByIdAsync(garageId);

        return Ok(garage);
    }

    [HttpPost]
    public async Task<IActionResult> AddGarage(GarageRequestDto garageRequestDto)
    {
        await _garageService.CreateGarageAsync(garageRequestDto);

        return Ok("Garage has been created");
    }

    [HttpDelete("{garageId:guid}")]
    public async Task<IActionResult> DeleteGarageById(Guid garageId)
    {
        await _garageService.DeleteGarageByIdAsync(garageId);

        return Ok($"Garage with Id: {garageId} Is Deleted.");
    }

    [HttpPost("{garageId}/{carId}")]
    public async Task<IActionResult> AddCarToGarage(CarRequestDto carRequestDto)
    {
        await _garageService.AddCarToGarageAsync(carRequestDto);
        return Ok($"Car is being added in{carRequestDto.GarageId}");
    }

    [HttpDelete("{garageId:guid}/{carId:guid}")]
    public async Task<IActionResult> RemoveCarsFromGarage(Guid garageId, Guid carId)
    {
        await _garageService.RemoveCarFromGarageAsync(garageId, carId);
        return Ok("Car is removed from db");
    }
}