using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using VehicleSummary.Api.Controllers;
using VehicleSummary.Api.Services.VehicleSummary;
using Xunit;

namespace VehicleSummary.IntegrationTests.VehicleChecksControllerTests
{
    public class VehicleChecksMakesShould
    {
        private VehicleSummaryService vehicleSummaryService;
        private VehicleChecksController vehicleChecksController;

        public VehicleChecksMakesShould()
        {
            vehicleSummaryService = new VehicleSummaryService();
            vehicleChecksController = new VehicleChecksController(vehicleSummaryService);
        }

        // check if GetSummaryByMake returns correct value
        [Fact]
        public async Task Call_GetSummaryByMake_CheckResult()
        {
            var make = "Lotus";

            var response = await vehicleSummaryService.GetSummaryByMake(make);
            var responsestring = JsonConvert.SerializeObject(response);

            var expect = "{\"make\":\"Lotus\",\"models\":[{\"name\":\"2 Eleven\",\"yearsAvailable\":2},{\"name\":\"Elan\",\"yearsAvailable\":1},{\"name\":\"Elise\",\"yearsAvailable\":14},{\"name\":\"Esprit\",\"yearsAvailable\":7},{\"name\":\"Europa\",\"yearsAvailable\":2},{\"name\":\"Evora\",\"yearsAvailable\":4},{\"name\":\"Excel\",\"yearsAvailable\":5},{\"name\":\"Exige\",\"yearsAvailable\":5}]}";
            Assert.Equal(expect.ToLower(), responsestring.ToLower());
        }

        // check if paaing in valid maker, the API will return OK Result
        [Fact]
        public async Task VehicleChecksController_Makes_withValidMake_ReturnsOK()
        {
            var make = "Lotus";

            var response = await vehicleChecksController.Makes(make);

            Assert.IsType<OkObjectResult>(response);
        }

        // check if paaing in invalid maker, the API will return NotFound Result
        [Fact]
        public async Task VehicleChecksController_Makes_withInvalidMake_ReturnsNotFound()
        {
            var make = "1";

            var response = await vehicleChecksController.Makes(make);

            Assert.IsType<NotFoundResult>(response);
        }

        // check if paaing in valid maker, the API will return OK Result
        [Fact]
        public async Task VehicleChecksController_Years_withValidMake_ReturnsOK()
        {
            var make = "Lotus";
            var model = "Excel";

            var response = await vehicleChecksController.Years(make,model);

            Assert.IsType<OkObjectResult>(response);
        }

        // check if paaing in valid maker, the API will return OK Result
        [Fact]
        public async Task VehicleChecksController_Years_withInValidMake_ReturnsNotFound()
        {
            var make = "1";
            var model = "2";

            var response = await vehicleChecksController.Years(make, model);

            Assert.IsType<NotFoundResult>(response);
        }
    }
}