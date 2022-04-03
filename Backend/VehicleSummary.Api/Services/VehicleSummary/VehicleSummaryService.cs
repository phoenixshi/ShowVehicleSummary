using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;


namespace VehicleSummary.Api.Services.VehicleSummary

{
    public interface IVehicleSummaryService
    {
        Task<VehicleSummaryResponse> GetSummaryByMake(string make);
        Task<List<string>> getModels(string make);
        Task<List<string>> getYearsOfModels(string make,string model);
    }
    
    public class VehicleSummaryService : IVehicleSummaryService
    {
        //Get a summary of models and year counts from a manufacturer
        public async Task<VehicleSummaryResponse> GetSummaryByMake(string make)
        {
            try 
            { 
                //check if the input is valid
                if (string.IsNullOrEmpty(make))
                {
                    throw new Exception("Manufacturer is required.");
                }

                VehicleSummaryResponse response = new VehicleSummaryResponse();
                response.Make = make;
                response.Models = new List<VehicleSummaryModels>();          

                //get all the models
                List<string> models = await getModels(make);
                if (models == null)
                    return null;

                foreach (string model in models)
                {
                    //get years for a particular model
                    var years = await getYearsOfModels(make,model);
                    if (years == null)
                        return null;

                    VehicleSummaryModels vsmodel = new VehicleSummaryModels();
                    vsmodel.Name = model;
                    vsmodel.YearsAvailable = years.Count;

                    response.Models.Add(vsmodel);     
                }

                return response;
            }
            catch(Exception ex)
            {
                //can add some log here with the exception message
                return null;
            }

        }

        /*
         Here's a small helper. We're using Flurl for http requests. (Change it if you wish)
         https://flurl.dev/
            
        async Task<List<string>> getModels(string make)
        {   
            var modelsUrl = "https://api.iag.co.nz/vehicles/vehicletypes/makes/Lotus/models?api-version=v1";

            var response = await modelsUrl
                .WithHeader("Ocp-Apim-Subscription-Key", "72ec78fb999e43be8dbdac94d7236cae")
                .GetJsonAsync<List<string>>();
                
            return response;
              
        }
        */

        //Get all models from a nanufacturer
        public async Task<List<string>> getModels(string make)
        {
            try
            {
                //check if the input is valid
                if (string.IsNullOrEmpty(make))
                {
                    throw new Exception("Manufacturer is required.");
                }

                var modelsUrl = $"https://api.iag.co.nz/vehicles/vehicletypes/makes/{make}/models?api-version=v1";

                var response = await modelsUrl
                    .WithHeader("Ocp-Apim-Subscription-Key", "72ec78fb999e43be8dbdac94d7236cae")
                    .GetJsonAsync<List<string>>();

                return response;
            }
            catch(Exception ex)
            {
                //can add some log here with the exception message
                return null;
            }
        }
        //Get all years from a particular manufacturer and a particular model
        public async Task<List<string>> getYearsOfModels(string make,string model)
        {
            try
            {
                //check if the input is valid
                if (string.IsNullOrEmpty(make) || string.IsNullOrEmpty(model))
                {
                    throw new Exception("Manufacturer And Model is required.");
                }

                var modelsUrl = $"https://api.iag.co.nz/vehicles/vehicletypes/makes/{make}/models/{model}/years?api-version=v1";

                var response = await modelsUrl
                    .WithHeader("Ocp-Apim-Subscription-Key", "72ec78fb999e43be8dbdac94d7236cae")
                    .GetJsonAsync<List<string>>();

                return response;
            }
            catch (Exception ex)
            {
                //can add some log here with the exception message
                return null;
            }
        }

    }
}