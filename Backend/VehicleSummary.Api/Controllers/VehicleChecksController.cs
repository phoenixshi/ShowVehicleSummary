using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleSummary.Api.Services.VehicleSummary;

namespace VehicleSummary.Api.Controllers
{
    public class VehicleChecksController : Controller
    {
        private readonly IVehicleSummaryService _vehicleSummaryService;

        public VehicleChecksController(IVehicleSummaryService vehicleSummaryService)
        {
            _vehicleSummaryService = vehicleSummaryService;
        }

        // GET
        // Returns models and years summary information for a maker
        [HttpGet]
        [Route("/vehicle-checks/makes/{make}")]
        public async Task<IActionResult> Makes(string make)
        {
            var response = await _vehicleSummaryService.GetSummaryByMake(make);
            if (response == null )
                return NotFound();
            
            return Ok(response);
        }

        // GET
        // Returns years of a particular model
        [HttpGet]
        [Route("/vehicle-checks/makes/{make}/model/{model}")]
        public async Task<IActionResult> Years(string make,string model)
        {
            var response = await _vehicleSummaryService.getYearsOfModels(make,model);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

    }
}