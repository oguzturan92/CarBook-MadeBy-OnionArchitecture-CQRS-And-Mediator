using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.TagClouds.Mediator.Queries.TagCloudQueries;
using Application.TagClouds.Mediator.Results.TagCloudResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Application.Interfaces.TagCloudInterfaces;

namespace Application.TagClouds.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _repository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetTagCloudsByBlogId(request.Id);
            var result = values.Select(value => new GetTagCloudByBlogIdQueryResult
            {
                TagCloudId = value.TagCloudId,
                TagCloudTitle = value.TagCloudTitle,
                BlogId = value.BlogId
            }).ToList();
            return result;
        }
    }
}