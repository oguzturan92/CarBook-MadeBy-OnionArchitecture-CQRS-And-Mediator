using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontends.Dtos.FeatureDtos
{
    public class UpdateFeatureDto
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
    }
}