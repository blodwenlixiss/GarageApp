namespace WebApplication1.Mapper.Car;

using Models.Entities;
using Models.Dtos;

public static class CarDtoMapper
{
    public static IEnumerable<CarDtoResponse> ToCarReadDto(this IEnumerable<Car> cars)
    {
        var carList = new List<CarDtoResponse>();

        foreach (var car in cars)
        {
            var carDto = new CarDtoResponse()
            {
                CarId = car.CarId,
                Model = car.Model,
                Make = car.Make,
                Year = car.Year,
                Color = car.Color,
            };

            carList.Add(carDto);
        }

        return carList;
    }    public static CarDtoResponse ToCarReadSoloDto(this Car cars)
    {
            var carDto = new CarDtoResponse()
            {
                CarId = cars.CarId,
                Model = cars.Model,
                Make = cars.Make,
                Year = cars.Year,
                Color = cars.Color,
            };
        return carDto;
    }
}