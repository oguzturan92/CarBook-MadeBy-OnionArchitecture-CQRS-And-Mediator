using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Locations.Mediator.Results.LocationResults;
using MediatR;

namespace Application.Locations.Mediator.Queries.LocationQueries
{
    public class GetLocationQuery : IRequest<List<GetLocationQueryResult>>
    {
        
    }
}