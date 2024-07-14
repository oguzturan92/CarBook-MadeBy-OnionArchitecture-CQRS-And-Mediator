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
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;
        public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var result = new GetPricingByIdQueryResult
            {
                PricingId = value.PricingId,
                PricingName = value.PricingName
            };
            return result;
        }
    }
}