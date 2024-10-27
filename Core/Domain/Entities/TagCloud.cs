using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TagCloud
    {
        public int TagCloudId { get; set; }
        public string TagCloudTitle { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}