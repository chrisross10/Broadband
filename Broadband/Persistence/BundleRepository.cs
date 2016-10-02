using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Broadband.Models;

namespace Broadband.Persistence
{
    public interface IBundleRepository
    {
        IEnumerable<BundleList> GetBundles();
    }

    public class BundleRepository : IBundleRepository
    {
        public IEnumerable<BundleList> GetBundles()
        {
            var apiConnection = CreateConnection();
            using (var client = new HttpClient())
            {
                client.BaseAddress = apiConnection.BaseAddress;
                client.DefaultRequestHeaders.Accept.Add(apiConnection.MediaType);
                var response = client.GetAsync(apiConnection.Endpoint).Result;
                var bundle = response.Content.ReadAsAsync<Bundle>().Result;
                return bundle.bundleList;
            }
        }

        private ApiConnection CreateConnection()
        {
            return new ApiConnection
            {
                BaseAddress = new Uri("http://api.broadbandchoices.co.uk/"),
                Endpoint = "api/v2/bestbuys?Authorization=eb45afb3-a7c2-4d6d-a62a-bb9a29a4fb2e",
                MediaType = new MediaTypeWithQualityHeaderValue("application/json")
            };
        }
    }
}