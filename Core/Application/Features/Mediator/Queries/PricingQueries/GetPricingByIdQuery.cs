using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Pricings.Mediator.Results.PricingResults;
using MediatR;

namespace Application.Pricings.Mediator.Queries.PricingQueries
{
    public class GetPricingByIdQuery : IRequest<GetPricingByIdQueryResult>
    {
        public int Id { get; set; }
        public GetPricingByIdQuery(int id)
        {
            Id = id;
        }
    }
}