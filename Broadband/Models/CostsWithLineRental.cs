using System.Collections.Generic;

namespace Broadband.Models
{
    public class CostsWithLineRental
    {
        public IList<MonthlyCostBreakdown> monthlyCostBreakdown { get; set; }
        public double monthlyCost { get; set; }
        public string monthlyCostDisplay { get; set; }
        public string monthlyCostNote { get; set; }
        public double firstYearCost { get; set; }
        public string firstYearCostDisplay { get; set; }
        public double lineRental { get; set; }
        public string lineRentalDisplay { get; set; }
        public IList<CostBreakdown> costBreakdown { get; set; }
        public double upfrontCostAfterOffer { get; set; }
        public string upfrontCostAfterOfferDisplay { get; set; }
        public double monthlyHardwardCost { get; set; }
        public object monthlyHardwardCostDisplay { get; set; }
        public double hardwareCost { get; set; }
        public string hardwareCostDisplay { get; set; }
        public double installationCost { get; set; }
        public string installationCostDisplay { get; set; }
        public double deliveryCost { get; set; }
        public string deliveryCostDisplay { get; set; }
    }
}