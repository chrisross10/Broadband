using System;
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
        private Random _random;
        private int _bundleId;

        [SetUp]
        public void SetUp()
        {
            var repository = Substitute.For<IBundleRepository>();

            _random = new Random();
            _bundleId = GetRandomId();
            var bundleList = new BundleList { bundleId = _bundleId };
            var bundles = new List<BundleList> { bundleList };
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
            var bundle = (BundleList)result.Model;

            Assert.That(bundle, Is.Not.Null);
            Assert.That(bundle.bundleId, Is.EqualTo(_bundleId));
        }

        private int GetRandomId()
        {
            return _random.Next(1, 9999);
        }
    }
}
