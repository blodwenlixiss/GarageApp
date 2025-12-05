using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace Infrastructure.Repositories;

public class CarRepository : ICarRepository
{
    private readonly AppDbContext _appDbContext;

    public CarRepository(AppDbContext context)
    {
        _appDbContext = context;
    }

    public async Task CreateCarAsync(Car car)
    {
        await _appDbContext.Cars.AddAsync(car);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteCarAsync(Car car)
    {
        _appDbContext.Cars.Remove(car);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        var allCars = await _appDbContext.Cars.ToListAsync();
        return allCars;
    }

    public async Task<IEnumerable<Garage>> GetGaragesWithCarIdAsync(Guid carId)
    {
        var garages = await _appDbContext.CarGarages
            .Include(cg => cg.Garage)
            .Where(cg => cg.CarId == carId)
            .Select(cg => cg.Garage)
            .ToListAsync();

        return garages;
    }

    public async Task<Car?> GetCarByIdAsync(Guid carId)
    {
        var car = await _appDbContext.Cars
            .FirstOrDefaultAsync(c => c.CarId == carId);

        return car;
    }

    public async Task<bool> CheckCarByIdAsync(Guid carId)
    {
        var car = await _appDbContext.Cars
            .AnyAsync(c => c.CarId == carId);

        return car;
    }
}