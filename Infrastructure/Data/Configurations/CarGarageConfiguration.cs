using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Entities;

namespace Infrastructure.Data.Configurations;

public class CarGarageConfiguration : IEntityTypeConfiguration<CarGarage>
{
    public void Configure(EntityTypeBuilder<CarGarage> builder)
    {
        builder
            .HasKey(cg => new { cg.CarId, cg.GarageId });

        builder
            .HasOne(cg => cg.Car)
            .WithMany(c => c.CarGarages)
            .HasForeignKey(cg => cg.CarId);

        builder
            .HasOne(cg => cg.Garage)
            .WithMany(c => c.CarGarages)
            .HasForeignKey(cg => cg.GarageId);
    }
}