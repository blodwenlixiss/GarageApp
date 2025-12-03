using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models.Dtos;
using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories;

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

    public async Task<bool> DeleteCarAsync(Guid carId)
    {
        var carForDelete = await _appDbContext.Cars.FindAsync(carId);
        if (carForDelete == null) return false;
        _appDbContext.Cars.Remove(carForDelete);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        var allCars = await _appDbContext.Cars.ToListAsync();
        return allCars;
    }

    public async Task<Car?> GetCarByIdAsync(Guid carId)
    {
        var car = await _appDbContext.Cars
            .FirstOrDefaultAsync(c => c.CarId == carId);

        if (car == null)
        {
            throw new Exception("Car is not found");
        }

  
        return car;
    }
}