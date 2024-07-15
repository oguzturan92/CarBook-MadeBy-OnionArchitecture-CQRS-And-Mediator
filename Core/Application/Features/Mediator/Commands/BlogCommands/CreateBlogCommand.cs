using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Blogs.Mediator.Commands.BlogCommands
{
    public class CreateBlogCommand : IRequest
    {
        public string BlogTitle { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogDate { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}