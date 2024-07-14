using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Locations.Mediator.Results.LocationResults;
using MediatR;

namespace Application.Locations.Mediator.Queries.LocationQueries
{
    public class GetLocationByIdQuery : IRequest<GetLocationByIdQueryResult>
    {
        public int Id { get; set; }
        public GetLocationByIdQuery(int id)
        {
            Id = id;
        }
    }
}