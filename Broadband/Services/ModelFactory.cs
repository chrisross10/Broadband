using System.Collections.Generic;
using System.Text.RegularExpressions;
using Broadband.Models;
using Broadband.Persistence;

namespace Broadband.Services
{
    public interface IModelFactory
    {
        IEnumerable<HomeViewModel> CreateModel();
    }

    public class ModelFactory : IModelFactory
    {
        private readonly IBundleRepository _repository;

        public ModelFactory(IBundleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<HomeViewModel> CreateModel()
        {
            var bundles = _repository.GetBundles();
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
            return model;
        }
    }
}