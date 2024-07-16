using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Mediator.Results.CarPricingResults;
using MediatR;

namespace Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingWithCarQuery : IRequest<List<GetCarPricingWithCarQueryResult>>
    {
        
    }
}