using Application.Dtos;
using WebApplication1.Mapper.CarGarage;

namespace WebApplication1.Mapper.Garage;

public static class GarageDtoMapper
{
    public static IEnumerable<GarageResponseDto> ToGarageResponseDtos(this IEnumerable<Entities.Garage> garages)
    {
        var test = garages.Select(x => new GarageResponseDto
        {
            GarageId = x.GarageId,
            GarageName = x.GarageName,
            Capacity = x.Capacity,
            Cars = x.CarGarages
                .Select(cg => cg.ToCarGarageDto())
                .ToList()
        });
        return test;
    }

    public static GarageResponseDto ToGarageDto(this Entities.Garage garage)
    {
        var garageDto = new GarageResponseDto
        {
            GarageId = garage.GarageId,
            GarageName = garage.GarageName,
            Capacity = garage.Capacity,
            Cars = garage.CarGarages
                .Select(cg => cg.ToCarGarageDto())
                .ToList()
        };
        return garageDto;
    }
}