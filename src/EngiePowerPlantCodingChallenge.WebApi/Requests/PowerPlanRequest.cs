using System.Text.Json.Serialization;
using EngiePowerPlantCodingChallenge.WebApi.DTO;
using EngiePowerPlantCodingChallenge.WebApi.Enums;
using EngiePowerPlantCodingChallenge.WebApi.Models;

namespace EngiePowerPlantCodingChallenge.WebApi.Requests
{
    public record PowerPlanRequest(
        [property: JsonPropertyName("load")] double Load,
        [property: JsonPropertyName("fuels")] Dictionary<string, double> Fuels,
        [property: JsonPropertyName("powerplants")] IReadOnlyList<PowerPlantRequest> Powerplants
    );

    public static class PowerPlanRequestDTOExtensions
    {
        public static PowerPlanRequestDTO ToDTO(this PowerPlanRequest request)
            => new(
                request.Load,
                request.Fuels.Select(f => new FuelPrice(
                    f.Value,
                    FuelTypeHelper.FromString(f.Key.Substring(0, f.Key.IndexOf('(')))
                )).Select(f => f.FixFuelPrice()),
                request.Powerplants.Select(pp => new PowerPlantDTO(
                    pp.Name,
                    pp.Type,
                    pp.Efficiency,
                    pp.PMin,
                    pp.PMax
                ))
            );

        private static FuelPrice FixFuelPrice(this FuelPrice fuel)
            => fuel.Type switch
            {
                FuelType.Wind
                    => new(Math.Round(fuel.Price / 100, 2), fuel.Type),
                _ => fuel
            };
    }

    public record PowerPlantRequest(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("efficiency")] double Efficiency,
        [property: JsonPropertyName("pmin")] double PMin,
        [property: JsonPropertyName("pmax")] double PMax
    );
}