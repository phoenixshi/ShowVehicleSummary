using System;
using System.Threading.Tasks;
using FluentAssertions;
using Flurl.Http.Testing;
using Newtonsoft.Json;
using VehicleSummary.Api.Services.VehicleSummary;
using Xunit;
using Xunit.Abstractions;
using FakeItEasy;
using System.Collections.Generic;

namespace VehicleSummary.UnitTests.ServicesTests.VehicleSummaryTests.VehicleSummaryServiceTests
{
    public class GetSummaryByMakeShould
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly IVehicleSummaryService _sut;

        public GetSummaryByMakeShould(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _sut = new VehicleSummaryService();
        }
        
        // checck if the right url is called when calling getModels
        [Fact]
        public async Task Call_Http_with_Get_Nedels_should_happen()
        {
            var make = "yo";
            //var sut = new VehicleSummaryService();

            using (var httpTest = new HttpTest())
            {                
                var response = await _sut.getModels(make);
                httpTest.ShouldHaveCalled($"https://api.iag.co.nz/vehicles/vehicletypes/makes/{make}/models?api-version=v1");
            }          
        }

        // checck if the right url is called when calling getYearsOfModels
        [Fact]
        public async Task Call_Http_with_getYearsOfModels_should_happen()
        {
            var make = "Lotus";
            var model = "Excel";
            //var sut = new VehicleSummaryService();;

            using (var httpTest = new HttpTest())
            {
                var response = await _sut.getYearsOfModels(make,model) ;
                httpTest.ShouldHaveCalled($"https://api.iag.co.nz/vehicles/vehicletypes/makes/{make}/models/{model}/years?api-version=v1");
            }
        }

        // check if exception is thrown when passing in invalid maker
        [Fact]
        public async Task Call_GetSummaryByMake_null_Check()
        {
            var make = "";
            //var sut = new VehicleSummaryService();
            Assert.ThrowsAsync<Exception>(async () => await _sut.GetSummaryByMake(make));
        }

    }
}