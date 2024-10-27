using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CarPricing
    {
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int PricingId { get; set; }
        public Pricing Pricing { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
    }
}