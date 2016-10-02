using System;
using System.Net.Http.Headers;

namespace Broadband.Persistence
{
    public class ApiConnection
    {
        public Uri BaseAddress { get; set; }
        public MediaTypeWithQualityHeaderValue MediaType { get; set; }
        public string Endpoint { get; set; }
    }
}