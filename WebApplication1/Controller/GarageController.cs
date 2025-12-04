using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Dtos;
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
    public async Task<IActionResult> GetSingleGarage(Guid garageId)
    {
        var garage = await _garageService.GetCarsInGarageAsync(garageId);

        return Ok(garage);
    }

    [HttpPost]
    public async Task<IActionResult> AddGarage(GarageDtoRequest garageDtoRequest)
    {
        await _garageService.CreateGarageAsync(garageDtoRequest);
        return Ok("Garage has been created");
    }

    [HttpDelete("{garageId:guid}")]
    public async Task<IActionResult> DeleteGarage(Guid garageId)
    {
        await _garageService.DeleteGarageAsync(garageId);
        return Ok($"Garage with Id: {garageId} Is Deleted.");
    }

    // Car to garage

    [HttpPost("{garageId}/{carId}")]
    public async Task<IActionResult> AddCarToGarage(Guid garageId, Guid carId)
    {
        await _garageService.AddCarToGarageAsync(garageId, carId);
        return Ok($"Car is being added in{garageId}");
    }

    [HttpDelete("{garageId:guid}/{carId:guid}")]
    public async Task<IActionResult> RemoveCarsFromGarage(Guid garageId, Guid carId)
    {
        await _garageService.RemoveCarFromGarageAsync(garageId, carId);
        return Ok("Car is removed from db");
    }
}