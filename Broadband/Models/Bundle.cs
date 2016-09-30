using System;
using System.Collections.Generic;

namespace Broadband.Models
{
    public class Bundle
    {
        public DateTime timeStamp { get; set; }
        public int errorCode { get; set; }
        public string postcode { get; set; }
        public int totalBundles { get; set; }
        public IList<BundleList> bundleList { get; set; }
    }
}