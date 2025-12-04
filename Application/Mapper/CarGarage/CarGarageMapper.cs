using Application.Dtos;

namespace WebApplication1.Mapper.CarGarage;

public static class CarGarageMapper
{
    public static CarGarageDto ToCarGarageDto(this Entities.CarGarage cg)
    {
        var carGarageDto = new CarGarageDto
        {
            CarId = cg.CarId,
            Make = cg.Car.Make,
            Model = cg.Car.Model,
            Color = cg.Car.Color,
            Year = cg.Car.Year,
            Quantity = cg.Quantity
        };

        return carGarageDto;
    }
}