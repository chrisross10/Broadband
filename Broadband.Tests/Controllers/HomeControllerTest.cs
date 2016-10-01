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
        private string _displaySpeed;
        private string _bundleType;

        [SetUp]
        public void SetUp()
        {
            var repository = Substitute.For<IBundleRepository>();

            _random = new Random();
            _bundleId = GetRandomInt();
            _downloadLimitDisplay = GetRandomString();
            _displaySpeed = GetRandomString();
            var bundleList = new BundleList
            {
                bundleId = _bundleId,
                downloadLimitDisplay = _downloadLimitDisplay,
                displaySpeed = _displaySpeed,
                bundleType = _bundleType
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
            Assert.That(viewModel.DownloadSpeed, Is.EqualTo(_displaySpeed));
            Assert.That(viewModel.BundleType, Is.EqualTo(_bundleType));
        }

        private int GetRandomInt()
        {
            return _random.Next(1, 9999);
        }

        private string GetRandomString()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
