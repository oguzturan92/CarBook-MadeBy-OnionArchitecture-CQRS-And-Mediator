using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Results.BlogResults
{
    public class GetAllBlogsWithAuthorQueryResult
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogSubTitle { get; set; }
        public string BlogDescription { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogDate { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryNameName { get; set; }
    }
}