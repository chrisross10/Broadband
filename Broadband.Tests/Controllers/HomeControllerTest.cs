using System.Collections.Generic;
using System.Web.Mvc;
using Broadband.Controllers;
using Broadband.Models;
using Broadband.Persistence;
using NSubstitute;
using NUnit.Framework;

namespace Broadband.Tests.Unit.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private HomeController _controller;

        [SetUp]
        public void SetUp()
        {
            var repository = Substitute.For<IBundleRepository>();
            var bundles = new List<BundleList> { new BundleList() };
            repository.GetBundles().Returns(bundles);
            _controller = new HomeController(repository);
        }

        [Test]
        public void Index()
        {
            var result = _controller.Index() as ViewResult;
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void It_gets_bundles()
        {
            var result = _controller.Index() as ViewResult;
            Assert.That(result.Model, Is.Not.Null);
        }
    }
}
