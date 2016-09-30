using System.Linq;
using System.Web.Mvc;
using Broadband.Persistence;

namespace Broadband.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBundleRepository _repository;

        public HomeController(IBundleRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var bundle = _repository.GetBundles().First();
            return View(bundle);
        }
    }
}