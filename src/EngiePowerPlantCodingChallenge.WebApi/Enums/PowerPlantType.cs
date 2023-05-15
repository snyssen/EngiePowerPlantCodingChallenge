using Ardalis.SmartEnum;

namespace EngiePowerPlantCodingChallenge.WebApi.Enums
{
    public enum PowerPlantType
    {
        GasFired,
        TurboJet,
        WindTurbine
        // public static PowerPlantType GasFired => new(nameof(GasFired), "gasfired");
        // public static PowerPlantType TurboJet => new(nameof(TurboJet), "turbojet");
        // public static PowerPlantType WindTurbine => new(nameof(WindTurbine), "windturbine");

        // public PowerPlantType(string name, string value) : base(name, value)
        // {
        // }

        // // TODO: Add FuelType ?
    }

    public static class PowerPlantTypeHelper
    {
        public static PowerPlantType FromString(string type)
            => type switch
            {
                "gasfired" => PowerPlantType.GasFired,
                "turbojet" => PowerPlantType.TurboJet,
                "windturbine" => PowerPlantType.WindTurbine,
                _ => throw new NotSupportedException($"PowerPlantType {type} is not supported")
            };
    }
}