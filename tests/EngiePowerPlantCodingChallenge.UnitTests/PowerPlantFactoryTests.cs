using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngiePowerPlantCodingChallenge.WebApi.DTO;
using EngiePowerPlantCodingChallenge.WebApi.Enums;
using EngiePowerPlantCodingChallenge.WebApi.Factories;
using EngiePowerPlantCodingChallenge.WebApi.Interfaces;
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

            IPowerPlant powerPlant = PowerPlantFactory.FromPowerPowerPlantDTO(dto);

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

            IPowerPlant powerPlant = PowerPlantFactory.FromPowerPowerPlantDTO(dto);

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

            IPowerPlant powerPlant = PowerPlantFactory.FromPowerPowerPlantDTO(dto);

            Assert.Equal(PowerPlantType.WindTurbine, powerPlant.Type);
        }
    }
}