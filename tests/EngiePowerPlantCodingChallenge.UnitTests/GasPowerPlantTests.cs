using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngiePowerPlantCodingChallenge.WebApi.Enums;
using EngiePowerPlantCodingChallenge.WebApi.Interfaces;
using EngiePowerPlantCodingChallenge.WebApi.Models;
using Xunit;

namespace EngiePowerPlantCodingChallenge.UnitTests
{
    public class GasPowerPlantTests
    {
        // gas(euro/MWh): the price of gas per MWh. Thus if gas is at 6 euro/MWh and if the efficiency of the powerplant is 50% (i.e. 2 units of gas will generate one unit of electricity), the cost of generating 1 MWh is 12 euro.
        [Fact]
        public void GetCostOfMWh_ExampleFromChallenge_ReturnsCorrectCost()
        {
            IPowerPlant powerPlant = GetDefaultPowerPlant();
            FuelPrice fuelPrice = new(6, FuelType.Gas);

            double costOfMWh = powerPlant.GetCostOfMWh(fuelPrice);

            Assert.Equal(12, costOfMWh);
        }

        [Fact]
        public void Constructor_NoOp_LoadIsZero()
        {
            IPowerPlant powerPlant = GetDefaultPowerPlant();

            Assert.Equal(0, powerPlant.CurrentLoad);
        }

        [Fact]
        public void TrySetLoad_ValidLoad_ReturnsTrueAndSetsLoad()
        {
            IPowerPlant powerPlant = GetDefaultPowerPlant();
            double load = 200;

            bool isSet = powerPlant.TrySetLoad(load);

            Assert.Equal(true, isSet);
            Assert.Equal(load, powerPlant.CurrentLoad);
        }
        [Fact]
        public void TrySetLoad_LoadUnderMinimum_ReturnsFalseAndDoesNotSetLoad()
        {
            IPowerPlant powerPlant = GetDefaultPowerPlant();
            double load = 500;

            bool isSet = powerPlant.TrySetLoad(load);

            Assert.Equal(false, isSet);
            Assert.Equal(0, powerPlant.CurrentLoad);
        }
        [Fact]
        public void TrySetLoad_LoadAboveMaximum_ReturnsFalseAndDoesNotSetLoad()
        {
            IPowerPlant powerPlant = GetDefaultPowerPlant();
            double load = 50;

            bool isSet = powerPlant.TrySetLoad(load);

            Assert.Equal(false, isSet);
            Assert.Equal(0, powerPlant.CurrentLoad);
        }

        private IPowerPlant GetDefaultPowerPlant()
            => new GasPowerPlant(
                "gasfired1",
                0.5,
                100,
                460
            );
    }
}