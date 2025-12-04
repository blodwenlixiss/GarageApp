using Application.Dtos;

namespace WebApplication1.Mapper.Car;

public static class CarDtoMapper
{
    public static IEnumerable<CarResponseDto> ToCarResponseDtos(this IEnumerable<Domain.Entities.Car> cars)
    {
        var carResponseDto = cars.Select(car => new CarResponseDto
        {
            CarId = car.CarId,
            Model = car.Model,
            Make = car.Make,
            Year = car.Year,
            Color = car.Color,
        });

        return carResponseDto;
    }

    public static CarResponseDto ToCarResponseDto(this Domain.Entities.Car cars)
    {
        var carResponseDto = new CarResponseDto
        {
            CarId = cars.CarId,
            Model = cars.Model,
            Make = cars.Make,
            Year = cars.Year,
            Color = cars.Color,
        };

        return carResponseDto;
    }
}