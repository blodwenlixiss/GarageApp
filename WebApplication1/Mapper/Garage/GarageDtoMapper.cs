using WebApplication1.Mapper.CarGarage;

namespace WebApplication1.Mapper.Garage;

using WebApplication1.Models.Entities;
using WebApplication1.Models.Dtos;

public static class GarageDtoMapper
{
    public static IEnumerable<GarageDto> ToGarageDto(this IEnumerable<Garage> garages)
    {
        var garageList = new List<GarageDto>();
        foreach (var garage in garages)
        {
            var garageDto = new GarageDto()
            {
                GarageName = garage.GarageName,
                Capacity = garage.Capacity,
            };

            garageList.Add(garageDto);
        }

        return garageList;
    }
    public static IEnumerable<GarageReadDto> ToGarageReadDto(this IEnumerable<Garage> garages)
    {
        var garageList = new List<GarageReadDto>();
        foreach (var garage in garages)
        {
            var garageDto = new GarageReadDto()
            {
                GarageId = garage.GarageId,
                GarageName = garage.GarageName,
                Capacity = garage.Capacity,
            };

            garageList.Add(garageDto);
        }

        return garageList;
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