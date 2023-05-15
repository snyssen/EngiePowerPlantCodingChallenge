using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngiePowerPlantCodingChallenge.WebApi.Interfaces;

namespace EngiePowerPlantCodingChallenge.WebApi.Models // TODO: Move to business namespace
{
    public record PowerPlan(
        double ExpectedLoad,
        IEnumerable<FuelPrice> FuelPrices,
        IEnumerable<IPowerPlant> PowerPlants
    )
    {
        private IOrderedEnumerable<IPowerPlant>? _orderedPowerPlants;
        public IOrderedEnumerable<IPowerPlant> OrderedPowerPlants
        {
            get
            {
                if (_orderedPowerPlants is null)
                {
                    _orderedPowerPlants = PowerPlants.OrderBy(pp => pp.GetCostOfMWh(FuelPrices.First(f => f.Type == pp.FuelType)));
                }
                return _orderedPowerPlants;
            }
        }

        public IEnumerable<PowerPlantOutput> GeneratePowerPlan()
        {
            double currentLoad = 0;
            List<IPowerPlant> powerPlants = new();
            foreach (IPowerPlant powerPlant in OrderedPowerPlants)
            {
                // Check if expected load is already reached. If so, set power plant load to 0
                if (currentLoad == ExpectedLoad)
                {
                    powerPlant.TrySetLoad(0); // No check here, we assume every power plant to be able to be turned off. This could change in the future of course
                    powerPlants.Add(powerPlant);
                    continue;
                }

                // Try adding power plant max load to global current load.
                // If we are still below expected load, save state and continue onto next power plant.
                if (currentLoad + powerPlant.PMax <= ExpectedLoad)
                {
                    if (!powerPlant.TrySetLoad(powerPlant.PMax))
                        throw new InvalidOperationException($"Given power plant cannot output load {powerPlant.PMax}. {powerPlant.ToString()}");
                    currentLoad += powerPlant.CurrentLoad;
                    powerPlants.Add(powerPlant);
                    continue;
                }

                // We are above the expected load, try setting current power plant to a lower value so exact load can be reached
                double missingLoadForExpectation = Math.Round(ExpectedLoad - currentLoad, 1);
                if (powerPlant.TrySetLoad(missingLoadForExpectation))
                {
                    currentLoad += powerPlant.CurrentLoad;
                    powerPlants.Add(powerPlant);
                    continue; // Expected load is reached!
                }

                // Power plant cannot achieve the missing load.
                // Loop through previous until one can
                // for (int i = powerPlants.Count - 1; i >= 0; i--)
                // {
                //     if (!powerPlants[i].TrySetLoad(missingLoadForExpectation))
                //         continue;

                //     // Recalculate load now that a previous power plant has taken the missing load, and re-evaluate 
                //     currentLoad = powerPlants.Sum(pp => pp.CurrentLoad);

                //     break;
                // }
            }

            // if (currentLoad != ExpectedLoad) throw new InvalidOperationException($"Expected load ({ExpectedLoad}) cannot be achieved with given power plants");

            return powerPlants.Select(pp => PowerPlantOutput.FromPowerPlant(pp));
        }
    }
}