using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.TagClouds.Mediator.Results.TagCloudResults;
using MediatR;

namespace Application.TagClouds.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByBlogIdQuery : IRequest<List<GetTagCloudByBlogIdQueryResult>>
    {
        public int Id { get; set; }
        public GetTagCloudByBlogIdQuery(int id)
        {
            Id = id;
        }
    }
}