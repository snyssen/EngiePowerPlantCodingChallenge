using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EngiePowerPlantCodingChallenge.WebApi.Models;

namespace EngiePowerPlantCodingChallenge.WebApi.Responses
{
    public record PowerPlanResponseItem(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("p")] double PowerOutput
    );

    public static class PowerPlanResponseItemExtensions
    {
        public static PowerPlanResponseItem ToResponse(this PowerPlantOutput output)
            => new(
                output.Name,
                Math.Round(output.PowerOutput, 1)
            );
    }
}