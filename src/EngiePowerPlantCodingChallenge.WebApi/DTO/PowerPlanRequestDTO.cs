using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngiePowerPlantCodingChallenge.WebApi.Enums;
using EngiePowerPlantCodingChallenge.WebApi.Factories;
using EngiePowerPlantCodingChallenge.WebApi.Interfaces;
using EngiePowerPlantCodingChallenge.WebApi.Models;
using EngiePowerPlantCodingChallenge.WebApi.Requests;

namespace EngiePowerPlantCodingChallenge.WebApi.DTO
{
    public record PowerPlanRequestDTO(
        double Load,
        IEnumerable<FuelPrice> FuelPrices,
        IEnumerable<PowerPlantDTO> PowerPlants
    );

    public static class PowerPlanRequestDTOExtensions
    {
        public static PowerPlan ToPowerPlan(this PowerPlanRequestDTO dto)
            => new(
                dto.Load,
                dto.FuelPrices,
                dto.PowerPlants.Select(pp => PowerPlantFactory.FromPowerPowerPlantDTO(pp, dto.FuelPrices))
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