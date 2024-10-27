using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Blogs.Mediator.Results.BlogResults
{
    public class GetBlogByIdQueryResult
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogSubTitle { get; set; }
        public string BlogDescription { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogDate { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImage { get; set; }
        public int CategoryId { get; set; }
    }
}