﻿using System.Linq;
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
            var bundle = _repository.GetBundles().First();
            var model = new HomeViewModel
            {
                UsageType = bundle.downloadLimitDisplay,
                DownloadSpeed = bundle.displaySpeed,
                BundleType = Regex.Replace(bundle.bundleType, "(\\B[A-Z])", " $1"),
                CallsType = bundle.callsDisplay,
                MonthlyCost = bundle.costsWithLineRental.monthlyCostDisplay,
                MonthlyCostNote = bundle.costsWithLineRental.monthlyCostNote
            };
            return View(model);
        }
    }
}