using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontends.Dtos.PricingDtos
{
    public class UpdatePricingDto
    {
        public int PricingId { get; set; }
        public string PricingName { get; set; }
    }
}