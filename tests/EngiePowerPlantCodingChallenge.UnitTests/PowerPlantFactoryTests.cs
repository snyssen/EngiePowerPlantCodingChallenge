using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngiePowerPlantCodingChallenge.WebApi.DTO;
using EngiePowerPlantCodingChallenge.WebApi.Enums;
using EngiePowerPlantCodingChallenge.WebApi.Factories;
using EngiePowerPlantCodingChallenge.WebApi.Interfaces;
using EngiePowerPlantCodingChallenge.WebApi.Models;
using Xunit;

namespace EngiePowerPlantCodingChallenge.UnitTests
{
    public class PowerPlantFactoryTests
    {
        [Fact]
        public void FromPowerPowerPlantDTO_GasFired_ReturnsGasPowerPlant()
        {
            PowerPlantDTO dto = new PowerPlantDTO(
                "gasfiredbig1",
                "gasfired",
                0.53,
                100,
                460
            );
            List<FuelPrice> fuels = new();

            IPowerPlant powerPlant = PowerPlantFactory.FromPowerPowerPlantDTO(dto, fuels);

            Assert.Equal(PowerPlantType.GasFired, powerPlant.Type);
        }

        [Fact]
        public void FromPowerPowerPlantDTO_TurboJet_ReturnsTurboJetPowerPlant()
        {
            PowerPlantDTO dto = new PowerPlantDTO(
                "tj1",
                "turbojet",
                0.3,
                0,
                16
            );
            List<FuelPrice> fuels = new();

            IPowerPlant powerPlant = PowerPlantFactory.FromPowerPowerPlantDTO(dto, fuels);

            Assert.Equal(PowerPlantType.TurboJet, powerPlant.Type);
        }
        [Fact]
        public void FromPowerPowerPlantDTO_WindTurbine_ReturnsWindTurbinePowerPlant()
        {
            PowerPlantDTO dto = new PowerPlantDTO(
                "windpark1",
                "windturbine",
                1,
                0,
                150
            );
            List<FuelPrice> fuels = new() { new FuelPrice(0.4, FuelType.Wind) };

            IPowerPlant powerPlant = PowerPlantFactory.FromPowerPowerPlantDTO(dto, fuels);

            Assert.Equal(PowerPlantType.WindTurbine, powerPlant.Type);
        }
    }
}