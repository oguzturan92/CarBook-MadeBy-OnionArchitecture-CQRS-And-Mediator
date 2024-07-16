using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontends.Dtos.CarPricingDto
{
    public class ResultCarPricingWithCarDto
    {
        public int CarPricingId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Amount { get; set; }
    }
}