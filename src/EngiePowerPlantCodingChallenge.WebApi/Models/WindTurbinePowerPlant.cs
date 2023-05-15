using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngiePowerPlantCodingChallenge.WebApi.Enums;
using EngiePowerPlantCodingChallenge.WebApi.Interfaces;

namespace EngiePowerPlantCodingChallenge.WebApi.Models
{
    public class WindTurbinePowerPlant : IPowerPlant
    {
        public string Name { get; }

        public PowerPlantType Type => PowerPlantType.WindTurbine;

        public double Efficiency => 1;

        public double PMin => 0; // Wind turbine are on/off and have fixed power outputs depending on the wind

        private double _theoreticalPMax;
        public double PMax => CurrentWind > 0 && _theoreticalPMax > 0
            ? _theoreticalPMax * CurrentWind
            : 0;
        /// <summary>
        /// Current wind defines the maximum output the turbine can provide
        /// </summary>
        /// <value></value>
        private double CurrentWind { get; set; } = 0;

        public WindTurbinePowerPlant(string name, double theoreticalPMax, double currentWind = 0)
        {
            Name = name;
            _theoreticalPMax = theoreticalPMax;
            CurrentWind = currentWind;
        }

        public double GetPricePerMWh(FuelPrice price)
            => 0; // Generating power using a wind turbine is always free
    }
}