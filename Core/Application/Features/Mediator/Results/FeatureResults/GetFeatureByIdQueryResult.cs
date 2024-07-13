using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Results.FeatureResults
{
    public class GetFeatureByIdQueryResult
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
    }
}