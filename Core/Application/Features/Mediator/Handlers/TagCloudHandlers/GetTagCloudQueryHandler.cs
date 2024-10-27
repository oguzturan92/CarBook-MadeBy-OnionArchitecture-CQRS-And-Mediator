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
    public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        private readonly IRepository<TagCloud> _repository;
        public GetTagCloudQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(x => new GetTagCloudQueryResult
            {
                TagCloudId = x.TagCloudId,
                TagCloudTitle = x.TagCloudTitle,
                BlogId = x.BlogId
            }).ToList();
            return result;
        }
    }
}