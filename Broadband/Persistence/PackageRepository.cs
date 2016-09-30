using System.Collections.Generic;
using Broadband.Models;

namespace Broadband.Persistence
{
    public class PackageRepository
    {
        public IEnumerable<BundleList> GetPackages()
        {
            return new List<BundleList>();
        }
    }
}