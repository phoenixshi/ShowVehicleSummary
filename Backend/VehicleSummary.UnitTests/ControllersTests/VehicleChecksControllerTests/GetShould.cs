using System;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using VehicleSummary.Api.Controllers;
using VehicleSummary.Api.Services.VehicleSummary;
using Xunit;

namespace VehicleSummary.UnitTests.ControllersTests.VehicleChecksControllerTests
{
    public class GetShould
    {
        private readonly VehicleChecksController _sut;
        private readonly IVehicleSummaryService _fakeVehicleSummaryService;

        public GetShould()
        {
            _fakeVehicleSummaryService = A.Fake<IVehicleSummaryService>();
            _sut = new VehicleChecksController(_fakeVehicleSummaryService);
        }
        
        //check if GetSummaryByMake is called when calling the API
        [Fact]
        public async Task Call_VehicleSummaryService_with_given_make()
        {
            var make = "Lotus";
            
            var response = await _sut.Makes(make);

            A.CallTo(() => _fakeVehicleSummaryService.GetSummaryByMake(make))
                .MustHaveHappened();
        }




    }
}