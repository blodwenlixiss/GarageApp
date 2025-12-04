using WebApplication1.Mapper.CarGarage;

namespace WebApplication1.Mapper.Garage;

using WebApplication1.Models.Entities;
using WebApplication1.Models.Dtos;

public static class GarageDtoMapper
{
    public static IEnumerable<GarageReadDto> ToGarageReadDto(this IEnumerable<Garage> garages)
    {
        var test = garages.Select(x => new GarageReadDto
        {
            GarageId = x.GarageId,
            GarageName = x.GarageName,
            Capacity = x.Capacity,
            Cars = x.CarGarages
                .Select(cg => CarGarageMapper.ToDto(cg))
                .ToList()
        });
        return test;
    }

    public static GarageReadDto ToGarageDto(this Garage garage)
    {
        var garageDto = new GarageReadDto
        {
            GarageId = garage.GarageId,
            GarageName = garage.GarageName,
            Capacity = garage.Capacity,
            Cars = garage.CarGarages
                .Select(cg => CarGarageMapper.ToDto(cg))
                .ToList()
        };
        return garageDto;
    }
}