using System;
using System.Linq;
using System.Net.Http.Headers;
using Broadband.Persistence;
using Broadband.Services;
using NUnit.Framework;

namespace Broadband.Tests.Integration
{
    [TestFixture]
    public class BundleRepositoryTests
    {
        private BundleRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new BundleRepository();
        }

        [Test]
        public void It_gets_bundles()
        {
            var bundles = _repository.GetBundles().ToList();
            Assert.That(bundles, Is.Not.Null);
            Assert.That(bundles.Any());
        }
    }
}
