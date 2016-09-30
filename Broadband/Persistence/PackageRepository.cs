using System.Collections.Generic;
using Broadband.Models;

namespace Broadband.Persistence
{
    public class PackageRepository
    {
        public IEnumerable<Package> GetPackages()
        {
            return new List<Package>();
        }
    }
}