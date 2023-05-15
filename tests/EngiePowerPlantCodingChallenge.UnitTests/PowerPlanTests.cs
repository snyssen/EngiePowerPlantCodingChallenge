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
    public class PowerPlanTests
    {
        [Fact]
        public void OrderedPowerPlants_ExamplePayload1_GetsOrderedCorrectly()
        {
            PowerPlan powerPlan = GetExamplePowerPlan();

            var orderedPowerPlants = powerPlan.OrderedPowerPlants;

            // Not really a complete test, but time constraints...
            Assert.Equal("tj1", orderedPowerPlants.Last().Name);
        }

        [Fact]
        public void GeneratePowerPlan_ExamplePayload1_ReturnAllPowerPlantsAndFirstThreeAreOn()
        {
            PowerPlan powerPlan = GetExamplePowerPlan();

            IEnumerable<PowerPlantOutput> powerPlanOutputs = powerPlan.GeneratePowerPlan();

            // It should return all power plants
            Assert.Equal(powerPlan.PowerPlants.Count(), powerPlanOutputs.Count());
            // First three should be on at the following outputs
            Assert.Equal(90, powerPlanOutputs.First().PowerOutput);
            Assert.Equal(21.6, powerPlanOutputs.ElementAt(1).PowerOutput);
            Assert.Equal(368.4, powerPlanOutputs.ElementAt(2).PowerOutput);
            // All others should be 0
            Assert.All(powerPlanOutputs.Skip(3), pp => Assert.Equal(0, pp.PowerOutput));
        }

        // https://github.com/gem-spaas/powerplant-coding-challenge/blob/master/example_payloads/payload1.json
        private PowerPlan GetExamplePowerPlan()
        {
            var fuelPrices = new List<FuelPrice>()
                {
                    new(13.4, FuelType.Gas),
                    new(50.8, FuelType.Kerosine),
                    new(20, FuelType.Co2),
                    new (0.6, FuelType.Wind)
                };
            return new(480,
                fuelPrices,
                new List<IPowerPlant>()
                {
                    new GasPowerPlant("gasfiredbig1", 0.53, 100, 460),
                    new GasPowerPlant("gasfiredbig2", 0.53, 100, 460),
                    new GasPowerPlant("gasfiredsomewhatsmaller", 0.37, 40, 210),
                    new TurboJetPowerPlant("tj1", 0.3, 0, 150),
                    new WindTurbinePowerPlant("windpark1", 150, 0.6),
                    new WindTurbinePowerPlant("windpark2", 36, 0.6)
                });
        }
    }
}