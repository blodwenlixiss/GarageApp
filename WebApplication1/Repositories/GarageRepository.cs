using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models.Dtos;
using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories;

public class GarageRepository : IGarageRepository
{
    private readonly AppDbContext _AppDbContecxt;

    public GarageRepository(AppDbContext context)
    {
        _AppDbContecxt = context;
    }

    public async Task CreateGarageAsync(Garage garage)
    {
        await _AppDbContecxt.Garages.AddAsync(garage);
        await _AppDbContecxt.SaveChangesAsync();
    }


    public async Task<bool> DeleteGarageAsync(Guid garageId)
    {
        var garageForDelete = await _AppDbContecxt.Garages.FindAsync(garageId);

        if (garageForDelete == null) return false;

        _AppDbContecxt.Garages.Remove(garageForDelete);
        await _AppDbContecxt.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<Garage>> GetAllGaragesAsync()
    {
        var allGarages =
            await _AppDbContecxt.Garages.Include(g => g.CarGarages).ThenInclude(cg => cg.Car).ToListAsync();

        return allGarages;
    }

    public async Task<bool> UpdateCapacityOfGarageAsync(Guid garageId, int newCapacity)
    {
        var garageForUpdate = await _AppDbContecxt.Garages.FindAsync(garageId);
        if (garageForUpdate != null) garageForUpdate.Capacity = newCapacity;
        await _AppDbContecxt.SaveChangesAsync();
        return true;
    }

    public async Task<Garage?> GetGarageByIdAsync(Guid garageId)
    {
        var garage = await _AppDbContecxt.Garages
            .Where(g => g.GarageId == garageId)
            .Include(g => g.CarGarages)
            .ThenInclude(cg => cg.Car)
            .FirstOrDefaultAsync();
        return garage;
    }
    //     var garage = await _garageRepository.GetGarageByIdAsync(garageId);


    public async Task<bool> AddCarToGarageAsync(CarGarage carGarage)
    {
        {
            await _AppDbContecxt.CarGarages.AddAsync(carGarage);
            await _AppDbContecxt.SaveChangesAsync();

            return true;
        }
    }

    public async Task<bool> RemoveCarFromGarageAsync(Guid garageId, Guid carId)
    {
        var garage = await _AppDbContecxt.Garages.FirstOrDefaultAsync(g => g.GarageId == garageId);
        if (garage == null) return false;

        var car = await _AppDbContecxt.Cars.FirstOrDefaultAsync(c => c.CarId == carId);
        if (car == null) return false;
        var exists = await _AppDbContecxt.CarGarages
            .FirstOrDefaultAsync(cg => cg.GarageId == garageId && cg.CarId == carId);

        _AppDbContecxt.CarGarages.Remove(exists);
        await _AppDbContecxt.SaveChangesAsync();
        return true;
    }
}