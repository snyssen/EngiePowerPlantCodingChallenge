using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngiePowerPlantCodingChallenge.WebApi.DTO;
using EngiePowerPlantCodingChallenge.WebApi.Models;
using EngiePowerPlantCodingChallenge.WebApi.Requests;
using EngiePowerPlantCodingChallenge.WebApi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EngiePowerPlantCodingChallenge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionPlanController : ControllerBase
    {
        [HttpPost(Name = "Get production plan")]
        public IEnumerable<PowerPlanResponseItem> Post([FromBody] PowerPlanRequest request)
            => request
                .ToDTO()
                .ToPowerPlan()
                .GeneratePowerPlan()
                .Select(pp => pp.ToResponse());
    }
}