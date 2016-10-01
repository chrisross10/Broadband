using System;
using System.Collections.Generic;
using System.Linq;
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
        private string _callsDisplay;
        private string _monthlyCostDisplay;
        private string _monthlyCostNote;

        [SetUp]
        public void SetUp()
        {
            var repository = Substitute.For<IBundleRepository>();

            _random = new Random();
            _bundleId = GetRandomInt();
            _downloadLimitDisplay = GetRandomString();
            _displaySpeed = GetRandomString();
            _callsDisplay = GetRandomString();
            _bundleType = GetRandomString();
            _monthlyCostDisplay = GetRandomString();
            _monthlyCostNote = GetRandomString();

            var bundleList = new BundleList
            {
                bundleId = _bundleId,
                downloadLimitDisplay = _downloadLimitDisplay,
                displaySpeed = _displaySpeed,
                bundleType = _bundleType,
                callsDisplay = _callsDisplay,
                costsWithLineRental = new CostsWithLineRental
                {
                    monthlyCostDisplay = _monthlyCostDisplay,
                    monthlyCostNote = _monthlyCostNote
                }
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
        public void It_loads_bundles_into_the_view()
        {
            var result = _controller.Index() as ViewResult;
            var viewModel = (List<HomeViewModel>)result.Model;

            Assert.That(viewModel, Is.Not.Null);
            Assert.That(viewModel.First().UsageType, Is.EqualTo(_downloadLimitDisplay));
            Assert.That(viewModel.First().DownloadSpeed, Is.EqualTo(_displaySpeed));
            Assert.That(viewModel.First().BundleType, Is.EqualTo(_bundleType));
            Assert.That(viewModel.First().CallsType, Is.EqualTo(_callsDisplay));
            Assert.That(viewModel.First().MonthlyCost, Is.EqualTo(_monthlyCostDisplay));
            Assert.That(viewModel.First().MonthlyCostNote, Is.EqualTo(_monthlyCostNote));
            Assert.That(viewModel.First().Id, Is.EqualTo(_bundleId));
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
