namespace EngiePowerPlantCodingChallenge.WebApi.Enums
{
    public enum FuelType
    {
        Gas,
        Kerosine,
        Co2,
        Wind

        // public static FuelType Gas => new(nameof(Gas), "gas");
        // public static FuelType Kerosine => new(nameof(Kerosine), "kerosine");
        // public static FuelType Co2 => new(nameof(Co2), "co2");
        // public static FuelType Wind => new(nameof(Wind), "wind");

        // public FuelType(string name, string value) : base(name, value)
        // {
        // }
    }

    public static class FuelTypeHelper
    {
        public static FuelType FromString(string type)
            => type switch
            {
                "gas" => FuelType.Gas,
                "kerosine" => FuelType.Kerosine,
                "co2" => FuelType.Co2,
                "wind" => FuelType.Wind,
                _ => throw new NotSupportedException($"FuelType {type} is not supported")
            };
    }
}