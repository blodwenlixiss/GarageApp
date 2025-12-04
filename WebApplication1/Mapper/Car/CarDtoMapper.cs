namespace WebApplication1.Mapper.Car;

using Models.Entities;
using Models.Dtos;

public static class CarDtoMapper
{
    public static IEnumerable<CarDtoRead> ToCarReadDto(this IEnumerable<Car> cars)
    {
        var carList = new List<CarDtoRead>();

        foreach (var car in cars)
        {
            var carDto = new CarDtoRead()
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
    }    public static CarDtoRead ToCarReadSoloDto(this Car cars)
    {
            var carDto = new CarDtoRead()
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