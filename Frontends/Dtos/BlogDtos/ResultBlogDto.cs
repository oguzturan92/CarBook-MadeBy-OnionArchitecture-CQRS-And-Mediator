using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontends.Dtos.BlogDtos
{
    public class ResultBlogDto
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogDate { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}