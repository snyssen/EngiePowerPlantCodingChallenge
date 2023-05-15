using System.Text.Json.Serialization;

namespace EngiePowerPlantCodingChallenge.WebApi.Requests
{
    public record PowerPlanRequest(
        [property: JsonPropertyName("load")] double Load,
        [property: JsonPropertyName("fuels")] Dictionary<string, double> Fuels,
        [property: JsonPropertyName("powerplants")] IReadOnlyList<PowerPlantRequest> Powerplants
    );

    public record PowerPlantRequest(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("efficiency")] double Efficiency,
        [property: JsonPropertyName("pmin")] double PMin,
        [property: JsonPropertyName("pmax")] double PMax
    );
}