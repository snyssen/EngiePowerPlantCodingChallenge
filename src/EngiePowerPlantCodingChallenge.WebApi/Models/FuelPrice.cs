using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngiePowerPlantCodingChallenge.WebApi.Enums;

namespace EngiePowerPlantCodingChallenge.WebApi.Models
{
    public record FuelPrice(
        double Price,
        FuelType Type
    );
}