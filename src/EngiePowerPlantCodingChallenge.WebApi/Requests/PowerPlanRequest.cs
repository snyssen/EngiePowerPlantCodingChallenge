using System.Text.Json.Serialization;

namespace EngiePowerPlantCodingChallenge.WebApi.Requests
{
    public record PowerPlanRequest(
        [property: JsonPropertyName("load")] int Load,
        [property: JsonPropertyName("fuels")] Dictionary<string, double> Fuels,
        [property: JsonPropertyName("powerplants")] IReadOnlyList<Powerplant> Powerplants
    );

    public record Powerplant(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("efficiency")] double Efficiency,
        [property: JsonPropertyName("pmin")] int Pmin,
        [property: JsonPropertyName("pmax")] int Pmax
    );
}