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
        private string _downloadLimitDisplay;

        [SetUp]
        public void SetUp()
        {
            var repository = Substitute.For<IBundleRepository>();

            _random = new Random();
            _bundleId = GetRandomId();
            _downloadLimitDisplay = GetRandomString();
            var bundleList = new BundleList
            {
                bundleId = _bundleId,
                downloadLimitDisplay = _downloadLimitDisplay
            };
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
            var viewModel = (HomeViewModel)result.Model;

            Assert.That(viewModel, Is.Not.Null);
            Assert.That(viewModel.UsageType, Is.EqualTo(_downloadLimitDisplay));
        }

        private int GetRandomId()
        {
            return _random.Next(1, 9999);
        }

        private string GetRandomString()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
