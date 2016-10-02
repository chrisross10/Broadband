using System;
using System.Linq;
using System.Net.Http.Headers;
using Broadband.Persistence;
using NUnit.Framework;

namespace Broadband.Tests.Integration
{
    [TestFixture]
    public class BundleRepositoryTests
    {
        private BundleRepository _repository;
        private ApiConnection _connection;

        [SetUp]
        public void SetUp()
        {
            _repository = new BundleRepository();
            _connection = new ApiConnection
            {
                BaseAddress = new Uri("http://api.broadbandchoices.co.uk/"),
                Endpoint = "api/v2/bestbuys?Authorization=eb45afb3-a7c2-4d6d-a62a-bb9a29a4fb2e",
                MediaType = new MediaTypeWithQualityHeaderValue("application/json")
            };
        }

        [Test]
        public void It_gets_bundles()
        {
            var bundles = _repository.GetBundles(_connection).ToList();
            Assert.That(bundles, Is.Not.Null);
            Assert.That(bundles.Any());
        }
    }
}
