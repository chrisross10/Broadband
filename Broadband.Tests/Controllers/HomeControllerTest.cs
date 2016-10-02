using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Broadband.Controllers;
using Broadband.Models;
using Broadband.Services;
using NSubstitute;
using NUnit.Framework;

namespace Broadband.Tests.Unit.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _controller;
        private Random _random;
        private int _id;

        [SetUp]
        public void SetUp()
        {
            _random = new Random();
            var factory = Substitute.For<IModelFactory>();
            _id = GetRandomInt();
            var homeViewModels = new List<HomeViewModel>
            {
                new HomeViewModel {Id = _id}
            };
            factory.CreateModel().Returns(homeViewModels);
            _controller = new HomeController(factory);
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
            Assert.That(viewModel.First().Id, Is.EqualTo(_id));
        }

        private int GetRandomInt()
        {
            return _random.Next(1, 9999);
        }
    }
}
