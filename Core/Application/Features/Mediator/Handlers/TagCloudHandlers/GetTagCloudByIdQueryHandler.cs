using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.TagClouds.Mediator.Queries.TagCloudQueries;
using Application.TagClouds.Mediator.Results.TagCloudResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.TagClouds.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _repository;
        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var result = new GetTagCloudByIdQueryResult
            {
                TagCloudId = value.TagCloudId,
                TagCloudTitle = value.TagCloudTitle,
                BlogId = value.BlogId
            };
            return result;
        }
    }
}