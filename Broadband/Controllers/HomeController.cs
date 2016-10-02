using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Broadband.Models;
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

        public HomeController()
        {
            _repository = new BundleRepository();
        }

        public ActionResult Index()
        {
            var bundles = _repository.GetBundles(new ApiConnection());
            var model = new List<HomeViewModel>();
            foreach (var b in bundles)
            {
                model.Add(new HomeViewModel
                {
                    UsageType = b.downloadLimitDisplay,
                    DownloadSpeed = b.displaySpeed,
                    BundleType = Regex.Replace(b.bundleType, "(\\B[A-Z])", " $1"),
                    CallsType = b.callsDisplay,
                    MonthlyCost = b.costsWithLineRental.monthlyCostDisplay,
                    MonthlyCostNote = b.costsWithLineRental.monthlyCostNote,
                    Id = b.bundleId
                });
            }
            return View(model);
        }
    }
}