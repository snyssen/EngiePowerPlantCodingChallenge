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
        FuelType FuelType { get; }
        double CurrentLoad { get; }

        /// <summary>
        /// Merit order function, get the cost of generating a single MWh
        /// </summary>
        /// <param name="price">price of given fuel</param>
        /// <returns>The cost of 1 MWh</returns>
        double GetCostOfMWh(FuelPrice price);
        /// <summary>
        /// Try setting a specific load. Returns true if set correctly, or false if requested load cannot be set.
        /// <see cref="CurrentLoad"/> reflects the load set here
        /// </summary>
        /// <param name="load"></param>
        /// <returns></returns>
        bool TrySetLoad(double load);
    }
}