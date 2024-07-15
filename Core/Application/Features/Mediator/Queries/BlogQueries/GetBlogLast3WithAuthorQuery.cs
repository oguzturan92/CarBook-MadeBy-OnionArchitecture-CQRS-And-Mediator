using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Blogs.Mediator.Results.BlogResults;
using MediatR;

namespace Application.Blogs.Mediator.Queries.BlogQueries
{
    public class GetBlogLast3WithAuthorQuery : IRequest<List<GetBlogLast3WithAuthorQueryResult>>
    {
        
    }
}