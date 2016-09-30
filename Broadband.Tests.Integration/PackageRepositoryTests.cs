using Broadband.Persistence;
using NUnit.Framework;

namespace Broadband.Tests.Integration
{
    [TestFixture]
    public class PackageRepositoryTests
    {
        [Test]
        public void It_gets_packages()
        {
            var repository = new PackageRepository();
            var packages = repository.GetPackages();

            Assert.That(packages, Is.Not.Null);
        }
    }
}
