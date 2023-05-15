using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngiePowerPlantCodingChallenge.WebApi.DTO;
using EngiePowerPlantCodingChallenge.WebApi.Enums;
using EngiePowerPlantCodingChallenge.WebApi.Interfaces;
using EngiePowerPlantCodingChallenge.WebApi.Models;

namespace EngiePowerPlantCodingChallenge.WebApi.Factories
{
    public static class PowerPlantFactory
    {
        public static IPowerPlant FromPowerPowerPlantDTO(PowerPlantDTO dto)
        {
            // I'm using a switch due to time constraints, but in a more complex application this could use MEF for example
            // to instantiate the correct power plant class based on the provided type
            switch (PowerPlantTypeHelper.FromString(dto.Type))
            {
                case PowerPlantType.GasFired:
                    return new GasPowerPlant(dto.Name, dto.Efficiency, dto.PMin, dto.PMax);
                case PowerPlantType.TurboJet:
                    return new TurboJetPowerPlant(dto.Name, dto.Efficiency, dto.PMin, dto.PMax);
                case PowerPlantType.WindTurbine:
                    return new WindTurbinePowerPlant(dto.Name, dto.PMax); // TODO: Find a way to input current wind
                default:
                    throw new NotSupportedException($"Power plant of type {dto.Type} is not supported");
            }
        }
    }
}