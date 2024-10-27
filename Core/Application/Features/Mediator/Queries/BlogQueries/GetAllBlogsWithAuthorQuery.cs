using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace Application.Features.Mediator.Queries.BlogQueries
{
    public class GetAllBlogsWithAuthorQuery : IRequest<List<GetAllBlogsWithAuthorQueryResult>>
    {
        
    }
}