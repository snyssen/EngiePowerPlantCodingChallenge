using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.SmartEnum;

namespace EngiePowerPlantCodingChallenge.WebApi.Enums
{
    public class FuelType : SmartEnum<FuelType, string>
    {
        public static FuelType Gas => new(nameof(Gas), "gas");
        public static FuelType Kerosine => new(nameof(Kerosine), "kerosine");
        public static FuelType Co2 => new(nameof(Co2), "co2");
        public static FuelType Wind => new(nameof(Wind), "wind");

        public FuelType(string name, string value) : base(name, value)
        {
        }
    }
}