using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngiePowerPlantCodingChallenge.WebApi.Enums;
using EngiePowerPlantCodingChallenge.WebApi.Interfaces;

namespace EngiePowerPlantCodingChallenge.WebApi.Models
{
    public abstract class FuelConsumingPowerPlant : IPowerPlant
    {
        public string Name { get; }
        public abstract PowerPlantType Type { get; }
        public double Efficiency { get; }
        public double PMin { get; }
        public double PMax { get; }

        protected FuelConsumingPowerPlant(string name, double efficiency, double pMin, double pMax)
        {
            Name = name;
            Efficiency = efficiency;
            PMin = pMin;
            PMax = pMax;
        }

        public double GetPricePerMWh(FuelPrice price)
            => price.Price / Efficiency; // TODO: Check if input fuel type is correct for powerplant type
    }
}