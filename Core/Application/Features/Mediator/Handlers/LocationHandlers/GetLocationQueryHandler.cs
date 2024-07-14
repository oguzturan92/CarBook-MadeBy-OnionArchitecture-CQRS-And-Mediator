using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Locations.Mediator.Queries.LocationQueries;
using Application.Locations.Mediator.Results.LocationResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Locations.Mediator.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> _repository;
        public GetLocationQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(x => new GetLocationQueryResult
            {
                LocationId = x.LocationId,
                LocationName = x.LocationName
            }).ToList();
            return result;
        }
    }
}