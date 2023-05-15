using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngiePowerPlantCodingChallenge.WebApi.Enums;
using EngiePowerPlantCodingChallenge.WebApi.Models;

namespace EngiePowerPlantCodingChallenge.WebApi.Interfaces
{
    public interface IPowerPlant
    {
        string Name { get; }
        PowerPlantType Type { get; }
        double Efficiency { get; }
        double PMin { get; }
        double PMax { get; }

        double GetPricePerMWh(FuelPrice price);
    }
}