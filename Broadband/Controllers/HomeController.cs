using System.Linq;
using System.Web.Mvc;
using Broadband.Persistence;
using Broadband.Services;

namespace Broadband.Controllers
{
    public class HomeController : Controller
    {
        private readonly IModelFactory _factory;

        public HomeController(IModelFactory factory)
        {
            _factory = factory;
        }

        public HomeController()
        {
            _factory = new ModelFactory(new BundleRepository());
        }

        public ActionResult Index()
        {
            var model = _factory.CreateModel().ToList();
            return View(model);
        }
    }
}