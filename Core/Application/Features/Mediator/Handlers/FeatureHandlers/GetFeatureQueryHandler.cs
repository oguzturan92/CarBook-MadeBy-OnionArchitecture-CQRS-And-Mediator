using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Mediator.Queries.FeatureQueries;
using Application.Features.Mediator.Results.FeatureResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;
        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(x => new GetFeatureQueryResult
            {
                FeatureId = x.FeatureId,
                FeatureName = x.FeatureName
            }).ToList();
            return result;
        }
    }
}