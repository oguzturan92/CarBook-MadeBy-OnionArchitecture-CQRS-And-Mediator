using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.TagClouds.Mediator.Results.TagCloudResults
{
    public class GetTagCloudQueryResult
    {
        public int TagCloudId { get; set; }
        public string TagCloudTitle { get; set; }
        public int BlogId { get; set; }
    }
}