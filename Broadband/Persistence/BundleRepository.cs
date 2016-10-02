using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Broadband.Models;

namespace Broadband.Persistence
{
    public interface IBundleRepository
    {
        IEnumerable<BundleList> GetBundles(ApiConnection apiConnection);
    }

    public class BundleRepository : IBundleRepository
    {
        public IEnumerable<BundleList> GetBundles(ApiConnection apiConnection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = apiConnection.BaseAddress;
                client.DefaultRequestHeaders.Accept.Add(apiConnection.MediaType);
                var response = client.GetAsync(apiConnection.Endpoint).Result;
                var bundle = response.Content.ReadAsAsync<Bundle>().Result;
                return bundle.bundleList;
            }
        }
    }

    public class ApiConnection
    {
        public Uri BaseAddress { get; set; }
        public MediaTypeWithQualityHeaderValue MediaType { get; set; }
        public string Endpoint { get; set; }
    }
}