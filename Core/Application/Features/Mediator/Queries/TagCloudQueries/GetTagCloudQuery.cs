using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.TagClouds.Mediator.Results.TagCloudResults;
using MediatR;

namespace Application.TagClouds.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudQuery : IRequest<List<GetTagCloudQueryResult>>
    {
        
    }
}