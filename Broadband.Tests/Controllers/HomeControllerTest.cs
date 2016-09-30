using System.Web.Mvc;
using Broadband.Controllers;
using NUnit.Framework;

namespace Broadband.Tests.Unit.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.That(result, Is.Not.Null);
        }
    }
}
