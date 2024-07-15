using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Authors.Mediator.Results.AuthorResults
{
    public class GetAuthorByIdQueryResult
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
        public string AuthorDescription { get; set; }
    }
}