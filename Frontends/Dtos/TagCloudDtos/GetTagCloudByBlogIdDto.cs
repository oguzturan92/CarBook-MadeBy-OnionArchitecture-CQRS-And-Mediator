using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.TagCloudDtos
{
    public class GetTagCloudByBlogIdDto
    {
        public int TagCloudId { get; set; }
        public string TagCloudTitle { get; set; }
        public int BlogId { get; set; }
    }
}