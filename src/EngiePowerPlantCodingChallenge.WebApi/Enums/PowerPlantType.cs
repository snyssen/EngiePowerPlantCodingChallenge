using Ardalis.SmartEnum;

namespace EngiePowerPlantCodingChallenge.WebApi.Enums
{
    public class PowerPlantType : SmartEnum<PowerPlantType, string>
    {
        public static PowerPlantType GasFired => new(nameof(GasFired), "gasfired");
        public static PowerPlantType TurboJet => new(nameof(TurboJet), "turbojet");
        public static PowerPlantType WindTurbine => new(nameof(WindTurbine), "windturbine");

        public PowerPlantType(string name, string value) : base(name, value)
        {
        }

        // TODO: Add FuelType ?
    }
}