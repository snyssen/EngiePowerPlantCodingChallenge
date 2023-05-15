using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngiePowerPlantCodingChallenge.WebApi.Interfaces;

namespace EngiePowerPlantCodingChallenge.WebApi.Models
{
    public record PowerPlantOutput(
        string Name,
        double PowerOutput
    )
    {
        public static PowerPlantOutput FromPowerPlant(IPowerPlant powerPlant)
            => new(powerPlant.Name, powerPlant.CurrentLoad);
    }
}