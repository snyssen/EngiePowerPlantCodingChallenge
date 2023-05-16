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
                double missingLoadForExpectation = Math.Round(ExpectedLoad - currentLoad, 2);
                if (powerPlant.TrySetLoad(missingLoadForExpectation))
                {
                    currentLoad += powerPlant.CurrentLoad;
                    powerPlants.Add(powerPlant);
                    continue; // Expected load is reached!
                }

                // Loop through previous plants and see if they can handle their currentLoad minus the current plant minimum load.
                // If they can, then current plant should be able to take min load + missing load
                double currentMinimumLoad = powerPlant.PMin;
                bool wasAbleToOffsetLoad = false;
                for (int i = powerPlants.Count - 1; i >= 0; i--)
                {
                    double reducedLoad = powerPlants[i].CurrentLoad - currentMinimumLoad;
                    if (powerPlants[i].TrySetLoad(reducedLoad))
                    {
                        wasAbleToOffsetLoad = true;
                        break;
                    }
                }

                // Since we removed the minimum load of current plant from a previous plant load,
                // we should now be missing this minimum load + the missing load. Furthermore, this should be above the minimum
                // load of the current plant (if it can have variable load)
                if (wasAbleToOffsetLoad)
                {
                    missingLoadForExpectation = Math.Round(currentMinimumLoad + missingLoadForExpectation, 2);
                    powerPlant.TrySetLoad(missingLoadForExpectation); // If it fails it will stay at 0 load
                    powerPlants.Add(powerPlant); // So we simply add it, no matter if it is set at 0. Next loops should fix missing load if it is at all possible.
                }

                // Finally, force a recalculation of current load. If current plant could not take load, we still won't be meeting the expected load.
                // Next plant will try to remediate that if it is possible.
                // If current plant was able to take load, then we should have reached the expected load and next plants output will be set to 0
                currentLoad = powerPlants.Sum(pp => pp.CurrentLoad);
            }

            // We could check if the algorithm was able to successfully achieve a result, but since it might be impossible in some cases
            // (for example when only given wind turbines with no variable load), I prefer to always return the (closest) result, even if it's incorrect
            // if (currentLoad != ExpectedLoad) throw new InvalidOperationException($"Expected load ({ExpectedLoad}) cannot be achieved with given power plants");

            return powerPlants.Select(pp => PowerPlantOutput.FromPowerPlant(pp));
        }
    }
}