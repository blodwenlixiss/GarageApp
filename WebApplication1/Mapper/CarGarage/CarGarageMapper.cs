using WebApplication1.Models.Dtos;
using WebApplication1.Models.Entities;

namespace WebApplication1.Mapper.CarGarage;

public static class CarGarageMapper
{
    public static CarGarageDto ToDto(Models.Entities.CarGarage cg)
    {
        return new CarGarageDto
        {
            CarId = cg.CarId,
            Make = cg.Car.Make,
            Model = cg.Car.Model,
            Color = cg.Car.Color,
            Year = cg.Car.Year,
            Quantity = cg.Quantity
        };
    }
}