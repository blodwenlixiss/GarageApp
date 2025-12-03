using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entities;

namespace WebApplication1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Garage> Garages { get; set; }
    
    public DbSet<CarGarage> CarGarages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarGarage>()
            .HasKey(cg => new { cg.CarId, cg.GarageId });

        modelBuilder.Entity<CarGarage>()
            .HasOne(cg => cg.Car)
            .WithMany(c => c.CarGarages)
            .HasForeignKey(cg => cg.CarId);
    
        modelBuilder.Entity<CarGarage>()
            .HasOne(cg => cg.Garage)
            .WithMany(c => c.CarGarages)
            .HasForeignKey(cg => cg.GarageId);
    }
}
