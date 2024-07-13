using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pricing
    {
        public int PricingId { get; set; }
        public string PricingName { get; set; }
        public List<CarPricing> CarPricings { get; set; }
    }
}