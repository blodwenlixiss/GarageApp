using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
using WebApplication1.Interfaces;

namespace Infrastructure.Repositories;

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


    public async Task DeleteGarageAsync(Garage garage)
    {
        _AppDbContecxt.Garages.Remove(garage);
        await _AppDbContecxt.SaveChangesAsync();
    }

    public async Task<IEnumerable<Garage>> GetAllGaragesAsync()
    {
        var allGarages =
            await _AppDbContecxt.Garages.Include(g => g.CarGarages).ThenInclude(cg => cg.Car).ToListAsync();

        return allGarages;
    }

    public async Task UpdateGarageAsync(Garage garage)
    {
        _AppDbContecxt.Garages.Update(garage);
        await _AppDbContecxt.SaveChangesAsync();
    }

    public async Task<Garage?> GetGarageByIdAsync(Guid garageId)
    {
        var garage = await _AppDbContecxt.Garages
            .Include(g => g.CarGarages)
            .ThenInclude(cg => cg.Car)
            .FirstOrDefaultAsync(g => g.GarageId == garageId);

        return garage;
    }

    public async Task<bool> CheckGarageById(Guid garageId)
    {
        var garage = await _AppDbContecxt.Garages
            .Include(g => g.CarGarages)
            .ThenInclude(cg => cg.Car)
            .AnyAsync(g => g.GarageId == garageId);
        return garage;
    }

    public async Task<bool> AddCarToGarageAsync(CarGarage carGarage)
    {
        await _AppDbContecxt.CarGarages.AddAsync(carGarage);
        await _AppDbContecxt.SaveChangesAsync();

        return true;
    }

    public async Task UpdateCarGarageAsync(CarGarage entity)
    {
        _AppDbContecxt.CarGarages.Update(entity);
        await _AppDbContecxt.SaveChangesAsync();
    }

    public async Task<CarGarage?> GetCarGarageByIdAsync(Guid garageId, Guid carId)
    {
        return await _AppDbContecxt.CarGarages
            .Include(cg => cg.Car)
            .Include(cg => cg.Garage)
            .FirstOrDefaultAsync(cg => cg.GarageId == garageId && cg.CarId == carId);
    }

    public async Task RemoveCarFromGarageAsync(CarGarage cg)
    {
        _AppDbContecxt.CarGarages.Remove(cg);
        await _AppDbContecxt.SaveChangesAsync();
    }
}