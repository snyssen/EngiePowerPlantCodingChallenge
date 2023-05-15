using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EngiePowerPlantCodingChallenge.WebApi.Responses
{
    public record PowerPlanResponseItem(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("p")] string PowerOutput
    );
}