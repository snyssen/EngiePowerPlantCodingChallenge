using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngiePowerPlantCodingChallenge.WebApi.Enums;
using EngiePowerPlantCodingChallenge.WebApi.Models;
using EngiePowerPlantCodingChallenge.WebApi.Requests;

namespace EngiePowerPlantCodingChallenge.WebApi.DTO
{
    public record PowerPlanRequestDTO(
        double Load,
        IEnumerable<FuelPrice> FuelPrices,
        IEnumerable<PowerPlantDTO> PowerPlants
    )
    {
        public static PowerPlanRequestDTO FromRequest(PowerPlanRequest request)
            => new(
                request.Load,
                request.Fuels.Select(f => new FuelPrice(
                    f.Value,
                    FuelTypeHelper.FromString(f.Key.Substring(0, f.Key.IndexOf('(')))
                )),
                request.Powerplants.Select(pp => new PowerPlantDTO(
                    pp.Name,
                    pp.Type,
                    pp.Efficiency,
                    pp.PMin,
                    pp.PMax
                ))
            );
    }

    public record PowerPlantDTO(
        string Name,
        string Type,
        double Efficiency,
        double PMin,
        double PMax
    );
}