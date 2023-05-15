using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngiePowerPlantCodingChallenge.WebApi.Enums;

namespace EngiePowerPlantCodingChallenge.WebApi.Models
{
    public class GasPowerPlant : FuelConsumingPowerPlant
    {
        public GasPowerPlant(string name, double efficiency, double pMin, double pMax) : base(name, efficiency, pMin, pMax)
        {
        }

        public override PowerPlantType Type => PowerPlantType.GasFired;
    }
}