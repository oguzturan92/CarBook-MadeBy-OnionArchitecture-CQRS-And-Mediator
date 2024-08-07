using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Pricings.Mediator.Queries.PricingQueries;
using Application.Pricings.Mediator.Results.PricingResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Pricings.Mediator.Handlers.PricingHandlers
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        private readonly IRepository<Pricing> _repository;
        public GetPricingQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(x => new GetPricingQueryResult
            {
                PricingId = x.PricingId,
                PricingName = x.PricingName
            }).ToList();
            return result;
        }
    }
}