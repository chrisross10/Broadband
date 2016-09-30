using System.Linq;
using Broadband.Persistence;
using NUnit.Framework;

namespace Broadband.Tests.Integration
{
    [TestFixture]
    public class BundleRepositoryTests
    {
        [Test]
        public void It_gets_bundles()
        {
            var repository = new BundleRepository();
            var bundles = repository.GetBundles().ToList();
            Assert.That(bundles, Is.Not.Null);
            Assert.That(bundles.Any());
        }
    }
}
