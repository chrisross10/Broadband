using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Broadband.Models;

namespace Broadband.Persistence
{
    public class BundleRepository: IBundleRepository
    {
        public IEnumerable<BundleList> GetBundles()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.broadbandchoices.co.uk/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("api/v2/bestbuys?Authorization=eb45afb3-a7c2-4d6d-a62a-bb9a29a4fb2e").Result;
                var bundle = response.Content.ReadAsAsync<Bundle>().Result;
                return bundle.bundleList;
            }
        }
    }

    public interface IBundleRepository
    {
        IEnumerable<BundleList> GetBundles();
    }
}