using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Pricings.Mediator.Results.PricingResults;
using MediatR;

namespace Application.Pricings.Mediator.Queries.PricingQueries
{
    public class GetPricingQuery : IRequest<List<GetPricingQueryResult>>
    {
        
    }
}